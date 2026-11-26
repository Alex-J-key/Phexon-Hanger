namespace Phexon_Hanger
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            btnMazeGame = new Button();
            btnShapex = new Button();
            SuspendLayout();
            // 
            // btnMazeGame
            // 
            btnMazeGame.Location = new Point(27, 37);
            btnMazeGame.Name = "btnMazeGame";
            btnMazeGame.Size = new Size(140, 59);
            btnMazeGame.TabIndex = 0;
            btnMazeGame.Text = "Maze Game";
            btnMazeGame.UseVisualStyleBackColor = true;
            btnMazeGame.Click += btnMazeGame_Click;
            // 
            // btnShapex
            // 
            btnShapex.Location = new Point(195, 37);
            btnShapex.Name = "btnShapex";
            btnShapex.Size = new Size(140, 59);
            btnShapex.TabIndex = 1;
            btnShapex.Text = "Shapex";
            btnShapex.UseVisualStyleBackColor = true;
            btnShapex.Click += btnShapex_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnShapex);
            Controls.Add(btnMazeGame);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmMain";
            Text = "Phexon Hanger";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnMazeGame;
        private Button btnShapex;
    }
}
