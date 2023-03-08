using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using YamlDotNet.RepresentationModel;

namespace Chess
{
    public partial class Board : Form
    {
        // Variables
        private int timer;
        private int selectedX;
        private int selectedY;
        private string[,] board;
        private string[,] moves;
        private int timer_per_move;
        private bool game_timer = false;
        private bool move_timer = false;
        private string player = "playerone";
        private int sec = 0, min = 0, hrs = 0;
        private Dictionary<string, int> score = new Dictionary<string, int>
        {
            {"playerone", 0 },
            {"playertwo", 0 },
        };
        private Dictionary<string, string> name = new Dictionary<string, string>
        {
            {"playerone", "" },
            {"playertwo", "" },
        };

        // Constructor - Initializes a game on load
        public Board(string playerone, string playertwo)
        {
            InitializeComponent();
            InitializeSettings();

            InitializeBoard();
            InitializeMoves();

            name["playerone"] = playerone;
            name["playertwo"] = playertwo;
            
            SetScores();

            panel1.Click += Panel1_Click;
        }

        private void InitializeSettings()
        {
            // Getting current working directy
            string loc = Application.StartupPath;
            int index = loc.IndexOf("bin");
            string path = loc.Substring(0, index);

            // Accessing settings.yml and loading values
            using var reader = new StreamReader(path + "\\settings.yml");
            var yaml = new YamlStream();
            yaml.Load(reader);
            var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;

            // Game timer
            if (Boolean.Parse((string)mapping.Children["timed_game"]) == false)
            {
                label4.Visible = false;
                game_timer = false;
            }
            else
            {
                label4.Visible = true;
                game_timer = true;
            }

            // Timed moves
            if(Boolean.Parse((string)mapping.Children["timed_move"]) == false)
            {
                label7.Visible = false;
                label8.Visible = false;
                move_timer = false;
                timer_per_move = 0;
            } 
            else
            {
                label7.Visible = true;
                label8.Visible = true;
                move_timer = true;
                timer_per_move = Int32.Parse((string)mapping.Children["time_per_move"]);
            }

            reader.Close();
        }


        // Panel functions
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            DrawCells(g);
            DrawMoves(g);

            panel3.BackColor = player == "playerone" ? Color.Green : Color.Red;
            panel4.BackColor = player == "playertwo" ? Color.Green : Color.Red;
        }
        private void Panel1_Click(object sender, EventArgs e)
        {
            Point click = panel1.PointToClient(Cursor.Position);
            var x = click.X / 110;
            var y = click.Y / 110;
            
            move_clicked(x, y);

            panel1.Refresh();
        }

        // Game functions
        private void move_clicked(int x, int y)
        {
            // King has been taken
            if(moves[y, x] == "+" && board[y, x][0] == 'K') 
            {
                board[y, x] = board[selectedY, selectedX];
                board[selectedY, selectedX] = "em";

                score[player]++;
                player = "";
                if (game_timer && timer1.Enabled) timer1.Stop();
                if (move_timer && timer2.Enabled) timer2.Stop();

                SetScores();
                InitializeMoves();
                return;
            }

            // A move
            if(moves[y, x] == "+") 
            {
                if (board[y, x] != "em")
                {
                    listBox1.Items.Add(board[y, x]);
                }
                board[y, x] = board[selectedY, selectedX];
                board[selectedY, selectedX] = "em";

                player = player == "playerone" ? "playertwo" : "playerone";
                if(move_timer && timer2.Enabled) timer = 0;

                InitializeMoves();
                return;
            }


            InitializeMoves();


            string piece = board[y, x];
            if (player == "") return;
            if (player == "playerone" && piece[1] == 'b') return;
            if (player == "playertwo" && piece[1] == 'w') return;

            moves[y, x] = piece;
            selectedX = x;
            selectedY = y;
            CalculateMoves(piece, x, y);
        }
        private void CalculateMoves(string piece, int x, int y)
        {
            char opponent = piece[1] == 'w' ? 'b' : 'w';

            switch (piece[0])
            {
                case 'p': // Pawn
                    if (piece[1] == 'w') // White pawn
                    {
                        // If nothing is infront
                        if (board[y + 1, x] == "em")
                        {
                            // Move once or twice
                            if (y == 1)
                            {
                                moves[y + 1, x] = "+";
                                if(board[y + 2, x] == "em") moves[y + 2, x] = "+";
                            } else moves[y + 1, x] = "+";
                        }

                        // Checking overtake
                        if(x != 7)
                        {
                            if (board[y + 1, x + 1] != "em" && board[y + 1, x + 1][1] != 'w') moves[y + 1, x + 1] = "+";
                        } 
                        if(x != 0)
                        {
                            if (board[y + 1, x - 1] != "em" && board[y + 1, x - 1][1] != 'w') moves[y + 1, x - 1] = "+";
                        }


                    } 
                    else // Black pawn
                    {
                        // If nothing is infront
                        if (board[y-1, x] == "em")
                        {
                            // Move once or twice
                            if (y == 6)
                            {
                                moves[y - 1, x] = "+";
                                if (board[y - 2, x] == "em") moves[y - 2, x] = "+";
                            } else moves[y - 1, x] = "+";
                        }

                        // Checking overtake
                        if (x != 7)
                        {
                            if (board[y - 1, x + 1] != "em" && board[y - 1, x + 1][1] != 'b') moves[y - 1, x + 1] = "+";
                        } 
                        if(x != 0)
                        {
                            if (board[y - 1, x - 1] != "em" && board[y - 1, x - 1][1] != 'b') moves[y - 1, x - 1] = "+";
                        }
                    }
                    break;
                case 'c': // Castle
                    // South
                    for (int i = y + 1; i < 8; i++)
                    {
                        if (board[i, x] != "em" && board[i, x][1] == opponent) // Has an item which is opposite
                        {
                            moves[i, x] = "+";
                            break;
                        } 
                        else if (board[i, x] != "em" && board[i, x][1] == piece[1]) break; // Has an item which is team
                        else if (board[i, x] == "em") moves[i, x] = "+"; // Empty space
                    }

                    // East
                    for (int i = x + 1; i < 8; i++)
                    {
                        if (board[y, i] != "em" && board[y, i][1] == opponent) // Has an item which is opposite
                        {
                            moves[y, i] = "+";
                            break;
                        } 
                        else if (board[y, i] != "em" && board[y, i][1] == piece[1]) break; // Has an item which is team
                        else if (board[y, i] == "em") moves[y, i] = "+"; // Empty space
                            
                    }

                    // North
                    for(int i = y - 1; i >= 0; i--)
                    {
                        if (board[i, x] != "em" && board[i, x][1] == opponent) // Has an item which is opposite
                        {
                            moves[i, x] = "+";
                            break;
                        }
                        else if (board[i, x] != "em" && board[i, x][1] == piece[1]) break; // Has an item which is team
                        else if (board[i, x] == "em") moves[i, x] = "+"; // Empty space
                    }

                    // West
                    for(int i = x - 1; i >= 0; i--)
                    {
                        if (board[y, i] != "em" && board[y, i][1] == opponent) // Has an item which is opposite
                        {
                            moves[y, i] = "+";
                            break;
                        }
                        else if (board[y, i] != "em" && board[y, i][1] == piece[1]) break; // Has an item which is team
                        else if (board[y, i] == "em") moves[y, i] = "+"; // Empty space
                    }
                    break;
                case 'k': // Knight
                    // South
                    if(y + 2 < 8)
                    {
                        if (x + 1 < 8)
                        {
                            if (board[y + 2, x + 1][1] != piece[1]) moves[y + 2, x + 1] = "+";
                        }
                        if (x - 1 >= 0)
                        {
                            if (board[y + 2, x - 1][1] != piece[1]) moves[y + 2, x - 1] = "+";
                        }
                    }

                    // East
                    if (x + 2 < 8)
                    {
                        if (y + 1 < 8)
                        {
                            if (board[y + 1, x + 2][1] != piece[1]) moves[y + 1, x + 2] = "+";
                        }
                        if (y - 1 >= 0)
                        {
                            if (board[y - 1, x + 2][1] != piece[1]) moves[y - 1, x + 2] = "+";
                        }
                    }

                    // North
                    if(y - 2 >= 0)
                    {
                        if(x + 1 < 8)
                        {
                            if (board[y - 2, x + 1][1] != piece[1]) moves[y - 2, x + 1] = "+";
                        }
                        if (x - 1 >= 0)
                        {
                            if (board[y - 2, x - 1][1] != piece[1]) moves[y - 2, x - 1] = "+";
                        }
                    }

                    // West
                    if(x - 2 >= 0)
                    {
                        if (y + 1 < 8)
                        {
                            if (board[y + 1, x - 2][1] != piece[1]) moves[y + 1, x - 2] = "+";
                        }
                        if (y - 1 >= 0)
                        {
                            if (board[y - 1, x - 2][1] != piece[1]) moves[y - 1, x - 2] = "+";
                        }
                    }
                    break;
                case 'b': // Bishop
                    // South East
                    for (int i = 1; i < 8; i++) 
                    {
                        if (y + i < 8 && x + i < 8) 
                        {
                            if (board[y + i, x + i][1] == piece[1]) break;
                            moves[y + i, x + i] = "+";
                            if (board[y + i, x + i][1] == opponent) break;
                        }
                    }

                    // South West
                    for (int i = 1; i < 8; i++) 
                    {
                        if (y + i < 8 && x - i >= 0)
                        {
                            if (board[y + i, x - i][1] == piece[1]) break;
                            moves[y + i, x - i] = "+";
                            if (board[y + i, x - i][1] == opponent) break;
                        }
                    }

                    // North East
                    for (int i = 1; i < 8; i++) 
                    {
                        if (y - i >= 0 && x + i < 8)
                        {
                            if (board[y - i, x + i][1] == piece[1]) break;
                            moves[y - i, x + i] = "+";
                            if (board[y - i, x + i][1] == opponent) break;
                        }
                    }

                    // North West
                    for (int i = 1; i < 8; i++) 
                    {
                        if (y - i >= 0 && x - i >= 0) 
                        {
                            if (board[y - i, x - i][1] == piece[1]) break;
                            moves[y - i, x - i] = "+";
                            if (board[y - i, x - i][1] == opponent) break;
                        }
                    }
                    break;
                case 'q':
                    // South East
                    for (int i = 1; i < 8; i++) 
                    {
                        if (y + i < 8 && x + i < 8)
                        {
                            if (board[y + i, x + i][1] == piece[1]) break;
                            moves[y + i, x + i] = "+";
                            if (board[y + i, x + i][1] == opponent) break;
                        }
                    }

                    // South West
                    for (int i = 1; i < 8; i++) 
                    {
                        if (y + i < 8 && x - i >= 0)
                        {
                            if (board[y + i, x - i][1] == piece[1]) break;
                            moves[y + i, x - i] = "+";
                            if (board[y + i, x - i][1] == opponent) break;
                        }
                    }

                    // North East
                    for (int i = 1; i < 8; i++) 
                    {
                        if (y - i >= 0 && x + i < 8)
                        {
                            if (board[y - i, x + i][1] == piece[1]) break;
                            moves[y - i, x + i] = "+";
                            if (board[y - i, x + i][1] == opponent) break;
                        }
                    }

                    // North West
                    for (int i = 1; i < 8; i++) 
                    {
                        if (y - i >= 0 && x - i >= 0)
                        {
                            if (board[y - i, x - i][1] == piece[1]) break;
                            moves[y - i, x - i] = "+";
                            if (board[y - i, x - i][1] == opponent) break;
                        }
                    }

                    // South
                    for (int i = y + 1; i < 8; i++)
                    {
                        if (board[i, x] != "em" && board[i, x][1] == opponent) // Has an item which is opposite
                        {
                            moves[i, x] = "+";
                            break;
                        }
                        else if (board[i, x] != "em" && board[i, x][1] == piece[1]) break; // Has an item which is team
                        else if (board[i, x] == "em") moves[i, x] = "+"; // Empty space
                    }

                    // East
                    for (int i = x + 1; i < 8; i++)
                    {
                        if (board[y, i] != "em" && board[y, i][1] == opponent) // Has an item which is opposite
                        {
                            moves[y, i] = "+";
                            break;
                        }
                        else if (board[y, i] != "em" && board[y, i][1] == piece[1]) break; // Has an item which is team
                        else if (board[y, i] == "em") moves[y, i] = "+"; // Empty space

                    }

                    // North
                    for (int i = y - 1; i >= 0; i--)
                    {
                        if (board[i, x] != "em" && board[i, x][1] == opponent) // Has an item which is opposite
                        {
                            moves[i, x] = "+";
                            break;
                        }
                        else if (board[i, x] != "em" && board[i, x][1] == piece[1]) break; // Has an item which is team
                        else if (board[i, x] == "em") moves[i, x] = "+"; // Empty space
                    }

                    // West
                    for (int i = x - 1; i >= 0; i--)
                    {
                        if (board[y, i] != "em" && board[y, i][1] == opponent) // Has an item which is opposite
                        {
                            moves[y, i] = "+";
                            break;
                        }
                        else if (board[y, i] != "em" && board[y, i][1] == piece[1]) break; // Has an item which is team
                        else if (board[y, i] == "em") moves[y, i] = "+"; // Empty space
                    }
                    break;
                case 'K':
                    // South
                    if (y + 1 < 8 && board[y + 1, x][1] != piece[1]) moves[y + 1, x] = "+";
                    // South East
                    if (y + 1 < 8 && x + 1 < 8 && board[y + 1, x + 1][1] != piece[1]) moves[y + 1, x + 1] = "+";
                    // East
                    if (x + 1 < 8 && board[y, x + 1][1] != piece[1]) moves[y, x + 1] = "+";
                    // North East
                    if (y - 1 >= 0 && x + 1 < 8 && board[y - 1, x + 1][1] != piece[1]) moves[y - 1, x + 1] = "+";
                    // North
                    if (y - 1 >= 0 && board[y - 1, x][1] != piece[1]) moves[y - 1, x] = "+";
                    // North West
                    if (y - 1 >= 0 && x - 1 >= 0 && board[y - 1, x - 1][1] != piece[1]) moves[y - 1, x - 1] = "+";
                    // West
                    if (x - 1 >= 0 && board[y, x - 1][1] != piece[1]) moves[y, x - 1] = "+";
                    // South West
                    if(y + 1 < 8 && x - 1 >= 0 & board[y + 1, x - 1][1] != piece[1]) moves[y + 1, x - 1] = "+";
                    break;
                default:
                    break;
            }
        }
        private void SetScores()
        {
            label1.Text = name["playerone"] + ": " + score["playerone"].ToString();
            label3.Text = name["playertwo"] + ": " + score["playertwo"].ToString();

            label5.Text = name["playerone"];
            label6.Text = name["playertwo"];
        }
        private void InitializeMoves()
        {
            moves = new string[8, 8] {
                { ".", ".", ".", ".", ".", ".", ".", ".", },
                { ".", ".", ".", ".", ".", ".", ".", ".", },
                { ".", ".", ".", ".", ".", ".", ".", ".", },
                { ".", ".", ".", ".", ".", ".", ".", ".", },
                { ".", ".", ".", ".", ".", ".", ".", ".", },
                { ".", ".", ".", ".", ".", ".", ".", ".", },
                { ".", ".", ".", ".", ".", ".", ".", ".", },
                { ".", ".", ".", ".", ".", ".", ".", ".", },
            };
        }
        private void DrawMoves(Graphics g)
        {
            for (int i = 0; i < moves.GetLength(0); i++)
            {
                for(int j=0; j<moves.GetLength(1); j++)
                {
                    // Empty cell
                    if (moves[j, i] == "+" && board[j, i] == "em") g.FillEllipse(new SolidBrush(Color.Yellow), new Rectangle(i*110+40, j*110+40, 30, 30));
                    
                    // Enemy cell
                    else if(moves[j, i] == "+" && board[j, i] != "em") g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(i * 110 + 40, j * 110 + 40, 30, 30));
                }
            }
        }
        private void InitializeBoard()
        {
            board = new string[8, 8] {
                { "cw", "kw", "bw", "qw", "Kw", "bw", "kw", "cw", },
                { "pw", "pw", "pw", "pw", "pw", "pw", "pw", "pw", },
                { "em", "em", "em", "em", "em", "em", "em", "em", },
                { "em", "em", "em", "em", "em", "em", "em", "em", },
                { "em", "em", "em", "em", "em", "em", "em", "em", },
                { "em", "em", "em", "em", "em", "em", "em", "em", },
                { "pb", "pb", "pb", "pb", "pb", "pb", "pb", "pb", },
                { "cb", "kb", "bb", "qb", "Kb", "bb", "kb", "cb", },
            };
        }
        private void DrawCells(Graphics g)
        {
            bool white;
            for(int i = 0; i < board.GetLength(0); i++)
            {
                if (i % 2 == 1) white = false;
                else white = true;
                for(int j =0; j < board.GetLength(1); j++)
                {
                    g.FillRectangle(new SolidBrush(white ? Color.White : Color.Black), new Rectangle(j*110, i*110, 110, 110));
                    white = !white;

                    switch(board[i, j][0])
                    {
                        case 'K':
                            if(board[i, j][1] == 'b') g.DrawImage(Properties.Resources.kingblack, new Point(j * 110, i * 110));
                            else g.DrawImage(Properties.Resources.kingwhite, new Point(j * 110, i * 110));
                            break;
                        case 'q':
                            if (board[i, j][1] == 'b') g.DrawImage(Properties.Resources.queenblack, new Point(j * 110, i * 110));
                            else g.DrawImage(Properties.Resources.queenwhite, new Point(j * 110, i * 110));
                            break;
                        case 'b':
                            if (board[i, j][1] == 'b') g.DrawImage(Properties.Resources.bishopblack, new Point(j * 110, i * 110));
                            else g.DrawImage(Properties.Resources.bishopwhite, new Point(j * 110, i * 110));
                            break;
                        case 'k':
                            if (board[i, j][1] == 'b') g.DrawImage(Properties.Resources.knightblack, new Point(j * 110, i * 110));
                            else g.DrawImage(Properties.Resources.knightwhite, new Point(j * 110, i * 110));
                            break;
                        case 'c':
                            if (board[i, j][1] == 'b') g.DrawImage(Properties.Resources.castleblack, new Point(j * 110, i * 110));
                            else g.DrawImage(Properties.Resources.castlewhite, new Point(j * 110, i * 110));
                            break;
                        case 'p':
                            if (board[i, j][1] == 'b') g.DrawImage(Properties.Resources.pawnblack, new Point(j * 110, i * 110));
                            else g.DrawImage(Properties.Resources.pawnwhite, new Point(j * 110, i * 110));
                            break;
                        default:
                            break;
                    }
                }
            }
        }


        // Reset Button
        private void button1_Click(object sender, EventArgs e)
        {
            InitializeBoard();
            InitializeMoves();

            if(game_timer)
            {
                sec = 0;
                min = 0; 
                hrs = 0;
                timer1.Start();
            }
            if(move_timer)
            {
                timer = 0;
                timer2.Start();
            }

            player = "playerone";
            panel1.Refresh();
            listBox1.Items.Clear();
        }

        // Game Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(game_timer)
            {
                sec++;
                if(sec == 60)
                {
                    sec = 0;
                    min++;
                    if(min == 60)
                    {
                        min = 0;
                        hrs++;
                    }
                }

                label4.Text = hrs.ToString("00") + ":" + min.ToString("00") + ":" + sec.ToString("00");
            }
            else
            {
                timer1.Stop();
            }
        }

        // Move Timer
        private void timer2_Tick(object sender, EventArgs e)
        {
            if(move_timer)
            {
                if(player == "playerone")
                {
                    label7.Text = (timer_per_move - timer).ToString("00");

                    timer++;
                    if(timer >= timer_per_move)
                    {
                        player = "playertwo";
                        timer = 0;
                        panel3.BackColor = player == "playerone" ? Color.Green : Color.Red;
                        panel4.BackColor = player == "playertwo" ? Color.Green : Color.Red;
                    }

                    label7.Text = (timer_per_move - timer).ToString("00");
                }
                else if(player == "playertwo")
                {
                    label8.Text = (timer_per_move - timer).ToString("00");

                    timer++;
                    if (timer >= timer_per_move)
                    {
                        player = "playerone";
                        timer = 0;
                        panel3.BackColor = player == "playerone" ? Color.Green : Color.Red;
                        panel4.BackColor = player == "playertwo" ? Color.Green : Color.Red;
                    }

                    label8.Text = (timer_per_move - timer).ToString("00");
                }
            }
            else
            {
                timer2.Stop();
            }
        }




        // Useless stuff
        private void cell1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Board_Load(object sender, EventArgs e)
        {

        }
    }
}