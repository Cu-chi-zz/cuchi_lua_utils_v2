
namespace cuchi_lua_utils_v2
{
    partial class App
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.appName = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pathPickerButton = new System.Windows.Forms.Button();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.logsButton = new System.Windows.Forms.CheckBox();
            this.logsTextBox = new System.Windows.Forms.RichTextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.percentLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // appName
            // 
            this.appName.AutoSize = true;
            this.appName.Font = new System.Drawing.Font("Trebuchet MS", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appName.ForeColor = System.Drawing.SystemColors.Control;
            this.appName.Location = new System.Drawing.Point(129, 9);
            this.appName.Name = "appName";
            this.appName.Size = new System.Drawing.Size(553, 81);
            this.appName.TabIndex = 0;
            this.appName.Text = "Cuchi Lua Utils V2";
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.White;
            this.startButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.startButton.FlatAppearance.BorderSize = 2;
            this.startButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.startButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(13, 188);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(779, 43);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // pathPickerButton
            // 
            this.pathPickerButton.BackColor = System.Drawing.Color.White;
            this.pathPickerButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.pathPickerButton.FlatAppearance.BorderSize = 2;
            this.pathPickerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.pathPickerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.pathPickerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pathPickerButton.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathPickerButton.Location = new System.Drawing.Point(12, 139);
            this.pathPickerButton.Name = "pathPickerButton";
            this.pathPickerButton.Size = new System.Drawing.Size(780, 43);
            this.pathPickerButton.TabIndex = 2;
            this.pathPickerButton.Text = "SELECT FOLDER";
            this.pathPickerButton.UseVisualStyleBackColor = false;
            this.pathPickerButton.Click += new System.EventHandler(this.pathPickerButton_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(13, 113);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(779, 20);
            this.pathTextBox.TabIndex = 3;
            // 
            // logsButton
            // 
            this.logsButton.AutoSize = true;
            this.logsButton.Location = new System.Drawing.Point(12, 407);
            this.logsButton.Name = "logsButton";
            this.logsButton.Size = new System.Drawing.Size(85, 17);
            this.logsButton.TabIndex = 4;
            this.logsButton.Text = "Enable Logs";
            this.logsButton.UseVisualStyleBackColor = true;
            this.logsButton.CheckStateChanged += new System.EventHandler(this.logsButton_CheckStateChanged);
            // 
            // logsTextBox
            // 
            this.logsTextBox.Location = new System.Drawing.Point(13, 237);
            this.logsTextBox.Name = "logsTextBox";
            this.logsTextBox.ReadOnly = true;
            this.logsTextBox.Size = new System.Drawing.Size(779, 164);
            this.logsTextBox.TabIndex = 6;
            this.logsTextBox.Text = "";
            this.logsTextBox.TextChanged += new System.EventHandler(this.logsTextBox_TextChanged);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(13, 430);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(779, 18);
            this.progressBar.TabIndex = 7;
            // 
            // percentLabel
            // 
            this.percentLabel.AutoSize = true;
            this.percentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.percentLabel.Location = new System.Drawing.Point(742, 407);
            this.percentLabel.Name = "percentLabel";
            this.percentLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.percentLabel.Size = new System.Drawing.Size(54, 20);
            this.percentLabel.TabIndex = 8;
            this.percentLabel.Text = "0.00%";
            this.percentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(132)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(804, 451);
            this.Controls.Add(this.percentLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.logsTextBox);
            this.Controls.Add(this.logsButton);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.pathPickerButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.appName);
            this.Name = "Form1";
            this.Text = "Cuchi Lua Utils V2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label appName;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button pathPickerButton;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.CheckBox logsButton;
        private System.Windows.Forms.RichTextBox logsTextBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label percentLabel;
    }
}

