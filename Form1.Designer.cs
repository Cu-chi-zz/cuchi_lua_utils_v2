
namespace cuchi_lua_utils_v2
{
    partial class Form1
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
            this.startButton.Location = new System.Drawing.Point(13, 212);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(779, 43);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // pathPickerButton
            // 
            this.pathPickerButton.Location = new System.Drawing.Point(12, 139);
            this.pathPickerButton.Name = "pathPickerButton";
            this.pathPickerButton.Size = new System.Drawing.Size(780, 43);
            this.pathPickerButton.TabIndex = 2;
            this.pathPickerButton.Text = "SELECT FOLDER";
            this.pathPickerButton.UseVisualStyleBackColor = true;
            this.pathPickerButton.Click += new System.EventHandler(this.pathPickerButton_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(13, 113);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.ReadOnly = true;
            this.pathTextBox.Size = new System.Drawing.Size(779, 20);
            this.pathTextBox.TabIndex = 3;
            // 
            // logsButton
            // 
            this.logsButton.AutoSize = true;
            this.logsButton.Location = new System.Drawing.Point(13, 189);
            this.logsButton.Name = "logsButton";
            this.logsButton.Size = new System.Drawing.Size(85, 17);
            this.logsButton.TabIndex = 4;
            this.logsButton.Text = "Enable Logs";
            this.logsButton.UseVisualStyleBackColor = true;
            this.logsButton.CheckStateChanged += new System.EventHandler(this.logsButton_CheckStateChanged);
            // 
            // logsTextBox
            // 
            this.logsTextBox.Location = new System.Drawing.Point(13, 261);
            this.logsTextBox.Name = "logsTextBox";
            this.logsTextBox.ReadOnly = true;
            this.logsTextBox.Size = new System.Drawing.Size(779, 163);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(132)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(804, 451);
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
    }
}

