/*
 * Created by SharpDevelop.
 * User: edenfield-john
 * Date: 1/30/2017
 * Time: 12:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;


namespace Crossword
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		Clues clue_window = new Clues();
		List<id_cells> idc = new List<id_cells>();
		public String puzzle_file = Application.StartupPath + "\\puzzles\\puzzle.pzl";
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			buildWordList();
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
		void AboutToolStripMenuItemClick(object sender, EventArgs e)
		{
			MessageBox.Show("Help About", "By John");
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			initializeBoard();
			clue_window.SetDesktopLocation(this.Location.X+ this.Width, this.Location.Y);
			clue_window.StartPosition = FormStartPosition.Manual;
			
			clue_window.Show();
			clue_window.clueGrid.AutoResizeColumns();
		}
		
		private void initializeBoard()
		{
			
			board.BackgroundColor = Color.Black;
			board.DefaultCellStyle.BackColor= Color.Black;
			
			for (int i = 0; i< 21; i++){
				board.Rows.Add();
			}
			
			foreach (DataGridViewColumn c in board.Columns) {
				c.Width = board.Width / board.Columns.Count;
			}
			
			foreach (DataGridViewRow r in board.Rows) {
				r.Height = board.Height / board.Rows.Count;
			}
			
			for (int row = 0; row < board.Rows.Count ; row++) {
				
				for (int col = 0; col < board.Columns.Count; col++) {
					board[col,row].ReadOnly = true ;
				}
			}
			
			foreach (id_cells i in idc) {
				int start_col = i.X;
				int start_row = i.Y;
				char[] word = i.Word.ToCharArray ();
				
				for(int j=0; j< word.Length; j++)
				{
					if(i.Direction.ToUpper() == "ACROSS")
						formatCell(start_row,start_col + j ,word[j].ToString());
					if(i.Direction.ToUpper() == "DOWN")
						formatCell(start_row+j,start_col,word[j].ToString());
				}
			}
		}
		
		private	void formatCell(int row, int col, string letter){
			DataGridViewCell c = board[col,row];
			
			c.Style.BackColor = Color.White;
			c.ReadOnly = false;
			c.Style.SelectionBackColor = Color.Cyan;
			c.Tag = letter;
			
		}
		void MainFormLocationChanged(object sender, EventArgs e)
		{
			clue_window.SetDesktopLocation(this.Location.X+ this.Width, this.Location.Y);
		}
		
		private void buildWordList()
		{
			string line = "";
			using (StreamReader s = new StreamReader(puzzle_file))
			{
				line = s.ReadLine();
				while((line= s.ReadLine()) !=null)
				{
					String[] l = line.Split('|');
					idc.Add(new id_cells(Int32.Parse(l[0]),Int32.Parse (l[1]),
					                     l[2],l[3],	l[4],l[5]));
					clue_window.clueGrid.Rows.Add(new string[]  {l[3],l[2],l[5]});
				}
			}
		}
		void BoardCellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
				try {
				board[e.ColumnIndex,e.RowIndex].Value = board[e.ColumnIndex,e.RowIndex].Value.ToString().ToUpper();
				} catch (Exception) {
					
					
				}
			
			try {
				if(board[e.ColumnIndex,e.RowIndex].Value.ToString().Length > 1)
					board[e.ColumnIndex,e.RowIndex].Value = board[e.ColumnIndex,e.RowIndex].Value.ToString().Substring(0,1);
				} catch (Exception) {
					
					
				}
			
			try {
				board[e.ColumnIndex,e.RowIndex].Value = board[e.ColumnIndex,e.RowIndex].Value.ToString();
				} catch (Exception) {
					
					
				}
			
			try {
				if(board[e.ColumnIndex,e.RowIndex].Value.ToString().ToUpper().Equals(board[e.ColumnIndex,e.RowIndex].Tag.ToString().ToUpper()))
					board[e.ColumnIndex,e.RowIndex].Style.ForeColor = Color.DarkGreen;
				else
					board[e.ColumnIndex,e.RowIndex].Style.ForeColor = Color.Red;
				} catch (Exception) {
					
					
				}
		}
		void BoardCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			String number="";
			
			if (idc.Any(c => (number = c.Number) != "" && c.X == e.ColumnIndex && c.Y == e.RowIndex)) {
				Rectangle r = new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
				e.Graphics.FillRectangle(Brushes.White,r);
				Font f = new Font(e.CellStyle.Font.FontFamily,7);
				e.Graphics.DrawString(number,f,Brushes.Black,r);
				e.PaintContent(e.ClipBounds);
				e.Handled = true;
			}
		}
		void OpenPuzzleToolStripMenuItemClick(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Crossword Puzzle|*.pzl";
			if (ofd.ShowDialog()== DialogResult.OK)
			{
				puzzle_file = ofd.FileName;
				board.Rows.Clear();
				clue_window.clueGrid.Rows.Clear();
				
				idc.Clear();
				
				buildWordList();
				initializeBoard();
				
			}
				
			
		}
	
	}
	
	
	
	public class id_cells{
		public int X;
		public int Y;
		public string Direction;
		public string Number;
		public string Word;
		public string Clue;
			
			public id_cells(int x, int y, string direction,string number, string word, string clue)
		{
			this.X = x;
			this.Y = y;
			this.Direction = direction;
			this.Number = number;
			this.Word = word;
			this.Clue = clue;
		}
	}
}
