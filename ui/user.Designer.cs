
namespace personal_info.ui
{
    partial class User
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.personalInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personalInfo = new System.Windows.Forms.GroupBox();
            this.show = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.addressOther = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fullName = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.genderNonBin = new System.Windows.Forms.RadioButton();
            this.genderWomen = new System.Windows.Forms.RadioButton();
            this.genderMan = new System.Windows.Forms.RadioButton();
            this.district = new System.Windows.Forms.ComboBox();
            this.city = new System.Windows.Forms.ComboBox();
            this.about = new System.Windows.Forms.GroupBox();
            this.labelAbout = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.personalInfo.SuspendLayout();
            this.about.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personalInformationToolStripMenuItem,
            this.aboutToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // personalInformationToolStripMenuItem
            // 
            this.personalInformationToolStripMenuItem.Name = "personalInformationToolStripMenuItem";
            resources.ApplyResources(this.personalInformationToolStripMenuItem, "personalInformationToolStripMenuItem");
            this.personalInformationToolStripMenuItem.Click += new System.EventHandler(this.personalInformationToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // personalInfo
            // 
            this.personalInfo.Controls.Add(this.show);
            this.personalInfo.Controls.Add(this.clear);
            this.personalInfo.Controls.Add(this.save);
            this.personalInfo.Controls.Add(this.label7);
            this.personalInfo.Controls.Add(this.label6);
            this.personalInfo.Controls.Add(this.label5);
            this.personalInfo.Controls.Add(this.addressOther);
            this.personalInfo.Controls.Add(this.label4);
            this.personalInfo.Controls.Add(this.phone);
            this.personalInfo.Controls.Add(this.label3);
            this.personalInfo.Controls.Add(this.fullName);
            this.personalInfo.Controls.Add(this.id);
            this.personalInfo.Controls.Add(this.label2);
            this.personalInfo.Controls.Add(this.label1);
            this.personalInfo.Controls.Add(this.genderNonBin);
            this.personalInfo.Controls.Add(this.genderWomen);
            this.personalInfo.Controls.Add(this.genderMan);
            this.personalInfo.Controls.Add(this.district);
            this.personalInfo.Controls.Add(this.city);
            resources.ApplyResources(this.personalInfo, "personalInfo");
            this.personalInfo.Name = "personalInfo";
            this.personalInfo.TabStop = false;
            this.personalInfo.Enter += new System.EventHandler(this.personalInfo_Enter);
            // 
            // show
            // 
            resources.ApplyResources(this.show, "show");
            this.show.Name = "show";
            this.show.UseVisualStyleBackColor = true;
            this.show.Click += new System.EventHandler(this.show_Click);
            // 
            // clear
            // 
            resources.ApplyResources(this.clear, "clear");
            this.clear.Name = "clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // save
            // 
            resources.ApplyResources(this.save, "save");
            this.save.Name = "save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // addressOther
            // 
            resources.ApplyResources(this.addressOther, "addressOther");
            this.addressOther.Name = "addressOther";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // phone
            // 
            resources.ApplyResources(this.phone, "phone");
            this.phone.Name = "phone";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // fullName
            // 
            resources.ApplyResources(this.fullName, "fullName");
            this.fullName.Name = "fullName";
            // 
            // id
            // 
            resources.ApplyResources(this.id, "id");
            this.id.Name = "id";
            this.id.TextChanged += new System.EventHandler(this.id_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // genderNonBin
            // 
            resources.ApplyResources(this.genderNonBin, "genderNonBin");
            this.genderNonBin.Name = "genderNonBin";
            this.genderNonBin.TabStop = true;
            this.genderNonBin.UseVisualStyleBackColor = true;
            // 
            // genderWomen
            // 
            resources.ApplyResources(this.genderWomen, "genderWomen");
            this.genderWomen.Name = "genderWomen";
            this.genderWomen.TabStop = true;
            this.genderWomen.UseVisualStyleBackColor = true;
            // 
            // genderMan
            // 
            resources.ApplyResources(this.genderMan, "genderMan");
            this.genderMan.Name = "genderMan";
            this.genderMan.TabStop = true;
            this.genderMan.UseVisualStyleBackColor = true;
            // 
            // district
            // 
            this.district.FormattingEnabled = true;
            resources.ApplyResources(this.district, "district");
            this.district.Name = "district";
            // 
            // city
            // 
            this.city.FormattingEnabled = true;
            resources.ApplyResources(this.city, "city");
            this.city.Name = "city";
            this.city.SelectedIndexChanged += new System.EventHandler(this.city_SelectedIndexChanged);
            // 
            // about
            // 
            this.about.Controls.Add(this.labelAbout);
            resources.ApplyResources(this.about, "about");
            this.about.Name = "about";
            this.about.TabStop = false;
            this.about.Enter += new System.EventHandler(this.about_Enter);
            // 
            // labelAbout
            // 
            resources.ApplyResources(this.labelAbout, "labelAbout");
            this.labelAbout.Name = "labelAbout";
            this.labelAbout.Click += new System.EventHandler(this.labelAbout_Click);
            // 
            // User
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.about);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.personalInfo);
            this.Name = "User";
            this.Load += new System.EventHandler(this.user_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.personalInfo.ResumeLayout(false);
            this.personalInfo.PerformLayout();
            this.about.ResumeLayout(false);
            this.about.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem personalInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox personalInfo;
        private System.Windows.Forms.RadioButton genderNonBin;
        private System.Windows.Forms.RadioButton genderWomen;
        private System.Windows.Forms.RadioButton genderMan;
        private System.Windows.Forms.ComboBox district;
        private System.Windows.Forms.ComboBox city;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fullName;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox addressOther;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button show;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.GroupBox about;
        private System.Windows.Forms.Label labelAbout;
    }
}