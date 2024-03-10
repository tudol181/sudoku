using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudoku._3
{
    public partial class Sudoku : Form
    {
        public Sudoku()
        {
            InitializeComponent();
            //creez celulele 
            CreateCells();
            //creez jocul
            Start_NewGame();
        }

        class SudokuCell : Button
        {
            public int Value { get; set; }
            public bool used { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public void Clear()
            {
                this.Text = string.Empty;
                this.used = false;
            }
        }
        SudokuCell[,] cells = new SudokuCell[9, 9];
        //creez celulele
        void CreateCells()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // creez si colorez in functie de pozitie celulele
                    cells[i, j] = new SudokuCell();
                    cells[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 20);
                    cells[i, j].Size = new Size(40, 40);
                    cells[i, j].ForeColor = SystemColors.ControlDarkDark;
                    cells[i, j].Location = new Point(i * 40, j * 40);
                    if(((i / 3) + (j / 3)) % 2 == 0)
                                cells[i, j].BackColor = Color.LightGray;
                    cells[i, j].FlatStyle = FlatStyle.Flat;
                    cells[i, j].FlatAppearance.BorderColor = Color.Black;
                    cells[i, j].X = i;
                    cells[i, j].Y = j;

                    // celule apasate
                    cells[i, j].KeyPress += Cell_keyPressed;

                    Panel1.Controls.Add(cells[i, j]);
                }
            }
        }
        private void Cell_keyPressed(object sender, KeyPressEventArgs e)
        {
            var cell = sender as SudokuCell;

            // verific daca e completat
            if (cell.used)
                return;

            int value;

            // adaug in celula valoarea
            if (int.TryParse(e.KeyChar.ToString(), out value))
            {
                // resetez daca valoare = 0
                if (value == 0)
                    cell.Clear();
                else
                    cell.Text = value.ToString();

                cell.ForeColor = SystemColors.ControlDarkDark;
            }
        }

        void Start_NewGame()
        {
            // elimin valorile din celule
            foreach (var cell in cells)
            {
                cell.Value = 0;
                cell.Clear();
            }
            // apelez recursiv pana gasesc si completez cu valori valide pentru 
            //fiecare pozitie
           // Find(0, -1);
           // Reveal();
        }

        Random random = new Random();

        int Find(int i, int j)
        {
            // incrementez i si j pentru a ma deplasa pe rand
            //daca j > 8 incrementez i pt a trece pe urmatorul rand
            j++;
            if(j > 8)
            {
                j = 0;
                i++;
                // verifica daca se termina linia
                if (i > 8 )
                    return 1;
            }
            var value = 0;
            var pos_values = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            do
            {
                //daca nu mai este nr disponibil 
                //ne intoarcem pe pozitie anterioara si incercam alt nr
                if (pos_values.Count < 1)
                {
                    cells[i, j].Value = 0;
                    return 0;
                }
                //alegem random un nr din cele ramase
                value = pos_values[random.Next(0, pos_values.Count)];
                cells[i, j].Value = value;
                //stergem valoarea alesa din lista
                pos_values.Remove(value);
            }
            while (Valid(value, i, j) == 0 || Find(i, j) == 0);
         //   cells[i, j].Text = value.ToString();
            return 1;
        }

        int Valid(int value, int x, int y)
        {
            for(int i = 0; i < 9; i++)
            {
                //verific pe verticala
                if (i != y && cells[x, i].Value == value)
                    return 0;
                //verific pe orizontala
                if (i != x && cells[i, y].Value == value)
                    return 0;
            }
            //verific patratul
            for(int i = x - (x % 3); i < x - (x % 3) + 3; i++)
            {
                for (int j = y - (y % 3); j < y - (y % 3) + 3; j++)
                {
                    if (i != x && j != y && cells[i, j].Value == value)
                        return 0;
                }
            }
            return 1;
        }
        //aleg random numerele la care dau reveal 
        void Reveal()
        {
            for(int i = 0; i < 50; i++)
            {
                var x = random.Next(9);
                var y = random.Next(9);
                //afisez valoarea
                cells[x, y].Text = cells[x, y].Value.ToString();
                //schimb culoarea
                cells[x, y].ForeColor = Color.Black;
                cells[x, y].used = true;

            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            Start_NewGame();
            Find(0, -1);
            Reveal();
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            var wrong = new List<SudokuCell>();
            //caut celulele gresite
            foreach (var cell in cells)
                if(cell.Value.ToString() != cell.Text)
                    wrong.Add(cell);
            if (wrong.Any())
            {
                //marchez cu rosu nr gresite
                foreach (var k in wrong)
                    k.ForeColor = Color.Red;
                MessageBox.Show("Incorrect");
            }
            else
                MessageBox.Show("Correct");
        }
    }
}
