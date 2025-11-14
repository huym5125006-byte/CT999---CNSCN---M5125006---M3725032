using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        private DataTable questionTable = new DataTable();
        private string csvPath = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string question = txtQuestion.Text.Trim();

            if (string.IsNullOrEmpty(question))
            {
                MessageBox.Show("Vui lòng nhập câu hỏi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string answer = GetAnswerFromCsv(question);

            if (string.IsNullOrEmpty(answer))
                answer = GenerateFakeAnswer(question);

            txtAnswer.Text = answer;

            // Nếu CSV có đường dẫn, lưu lại nếu là câu hỏi mới
            if (!string.IsNullOrEmpty(csvPath))
                AppendToCsv(csvPath, question, answer);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV files (*.csv)|*.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                csvPath = ofd.FileName;
                LoadCsv(csvPath);
                MessageBox.Show("Tải dữ liệu CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadCsv(string filePath)
        {
            questionTable = new DataTable();

            // Use TextFieldParser to handle quoted fields with commas
            using (var parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;

                if (!parser.EndOfData)
                {
                    string[] headers = parser.ReadFields();
                    foreach (string header in headers)
                    {
                        questionTable.Columns.Add(header);
                    }
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();

                        // Ensure fields array matches number of columns: pad or truncate as needed
                        if (fields.Length != questionTable.Columns.Count)
                        {
                            var adjusted = new string[questionTable.Columns.Count];
                            int copy = Math.Min(fields.Length, adjusted.Length);
                            Array.Copy(fields, adjusted, copy);
                            for (int i = copy; i < adjusted.Length; i++)
                                adjusted[i] = string.Empty;
                            questionTable.Rows.Add(adjusted);
                        }
                        else
                        {
                            questionTable.Rows.Add(fields);
                        }
                    }
                }
            }
        }

        // Tìm câu trả lời trong DataTable (CSV đã tải)
        private string GetAnswerFromCsv(string question)
        {
            if (questionTable.Rows.Count == 0)
                return null;

            int qIdx = GetColumnIndex("Question");
            int aIdx = GetColumnIndex("Answer");

            // If expected columns aren't present, try sensible defaults (index 1 and 2),
            // otherwise return null to avoid misleading results.
            if (qIdx == -1 || aIdx == -1)
            {
                if (questionTable.Columns.Count >= 3)
                {
                    qIdx = (qIdx == -1) ? 1 : qIdx;
                    aIdx = (aIdx == -1) ? 2 : aIdx;
                }
                else
                {
                    return null;
                }
            }
            foreach (DataRow row in questionTable.Rows)
            {
                var q = row[qIdx]?.ToString() ?? string.Empty;
                if (string.Equals(q, question, StringComparison.OrdinalIgnoreCase))
                    return row[aIdx]?.ToString();
            }
            return null;
        }

        private int GetColumnIndex(string name)
        {
            for (int i = 0; i < questionTable.Columns.Count; i++)
            {
                if (string.Equals(questionTable.Columns[i].ColumnName, name, StringComparison.OrdinalIgnoreCase))
                    return i;
            }
            return -1;
        }

        private string EscapeForCsv(string value)
        {
            if (value == null) return string.Empty;
            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n") || value.Contains("\r"))
            {
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            }
            return value;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtQuestion.Clear();
            txtAnswer.Clear();
        }
    }
}
