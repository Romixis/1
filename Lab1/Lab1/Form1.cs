namespace Lab1
{
    public partial class Form1 : Form
    {
        public const int n = 5; // ������ ���������� �������
        public int[,] matrix = new int[n, n];
        public int numberLeft;
        public int numberRight;
        public double minDown;
        public double maxUp;

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;  // ����� ����� �� ������ ������    
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = n; // �������� ����� 5 �� 5 � dataGridView
            dataGridView1.RowCount = n;
            label4.Text = "";
            label5.Text = "";
        }

        // ��������� ������� � dataGridView
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                if (textBox1.Text == "" || textBox2.Text == "") // �������� �� ������������� ������
                {
                    MessageBox.Show("������� c ������ � �� ������ ����� ����� ������������� �������!", "������");
                    return;
                }

                numberRight = Convert.ToInt32(textBox1.Text);
                numberLeft = Convert.ToInt32(textBox2.Text);

                if (numberRight < numberLeft) // �������� �� ���� ������
                {
                    MessageBox.Show("������ ������� �� ����� ���� ������ �����!", "������");
                    return;
                }

                Random random = new Random();
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        //matrix[i, j] = random.Next(numberLeft, numberRight + 1);
                        dataGridView1.Rows[i].Cells[j].Value = random.Next(numberLeft, numberRight + 1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            label5.Text = "";
            label7.Text = "";
            try
            {
                for (int i = 0; i < n; ++i)
                {
                    maxUp = -999999999999999999;
                    minDown = 999999999999999999;
                    for (int j = 0; j < n; ++j)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value == null) // ��������, ���� �� ����� � dataGridView
                        {
                            MessageBox.Show("��������� ��� ����� � �������!", "������");
                            return;
                        }

                        if (!int.TryParse(dataGridView1.Rows[i].Cells[j].Value.ToString(), out matrix[i, j])) // ��������, ���� ��
                        {
                            MessageBox.Show("���-�� ���� ����� ��� ������� ����� � �������!", "������");
                            return;
                        }
                    }
                }
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        if (j < i && matrix[i, j] < minDown) // ������ ���������
                        {
                            minDown = matrix[i, j];
                        }
                        if (j > i && matrix[i, j] > maxUp) // ������� ���������
                        {
                            maxUp = matrix[i, j];
                        }
                    }
                }

                label4.Text = Convert.ToString(minDown);
                label5.Text = Convert.ToString(maxUp);
                label7.Text = Convert.ToString((minDown + maxUp) / 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}