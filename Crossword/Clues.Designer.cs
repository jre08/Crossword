/*
 * Created by SharpDevelop.
 * User: edenfield-john
 * Date: 1/30/2017
 * Time: 1:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Crossword
{
	partial class Clues
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.DataGridView clueGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.clueGrid = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.clueGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// clueGrid
			// 
			this.clueGrid.AllowUserToAddRows = false;
			this.clueGrid.AllowUserToDeleteRows = false;
			this.clueGrid.AllowUserToResizeColumns = false;
			this.clueGrid.AllowUserToResizeRows = false;
			this.clueGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.clueGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.Column1,
			this.Column2,
			this.Column3});
			this.clueGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.clueGrid.Location = new System.Drawing.Point(0, 0);
			this.clueGrid.Name = "clueGrid";
			this.clueGrid.RowHeadersVisible = false;
			this.clueGrid.Size = new System.Drawing.Size(384, 531);
			this.clueGrid.TabIndex = 0;
			// 
			// Column1
			// 
			this.Column1.HeaderText = "#";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 35;
			// 
			// Column2
			// 
			this.Column2.HeaderText = "Direction";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			// 
			// Column3
			// 
			this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column3.HeaderText = "Clue";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			// 
			// Clues
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 531);
			this.Controls.Add(this.clueGrid);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Clues";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Clues";
			((System.ComponentModel.ISupportInitialize)(this.clueGrid)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
