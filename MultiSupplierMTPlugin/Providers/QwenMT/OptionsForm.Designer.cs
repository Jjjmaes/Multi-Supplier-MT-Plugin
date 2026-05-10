using MultiSupplierMTPlugin.Forms;
using MultiSupplierMTPlugin.ProviderdsCommon;
using MultiSupplierMTPlugin.ProviderdsCommon.Forms;

namespace MultiSupplierMTPlugin.Providers.QwenMT
{
    partial class OptionsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.linkLabelApiKey = new System.Windows.Forms.LinkLabel();
            this.textBoxApiKey = new System.Windows.Forms.TextBox();
            this.labelRegion = new System.Windows.Forms.Label();
            this.comboBoxRegion = new System.Windows.Forms.ComboBox();
            this.labelCustomUrl = new System.Windows.Forms.Label();
            this.textBoxCustomUrl = new System.Windows.Forms.TextBox();
            this.labelModel = new System.Windows.Forms.Label();
            this.comboBoxModel = new System.Windows.Forms.ComboBox();
            this.checkAutoSource = new System.Windows.Forms.CheckBox();
            this.labelDomain = new System.Windows.Forms.Label();
            this.textBoxDomain = new System.Windows.Forms.TextBox();
            this.checkGlossary = new System.Windows.Forms.CheckBox();
            this.checkTm = new System.Windows.Forms.CheckBox();
            this.commonBottomControl = new MultiSupplierMTPlugin.ProviderdsCommon.Forms.CommonBottomControl();
            this.SuspendLayout();
            //
            // linkLabelApiKey
            //
            this.linkLabelApiKey.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelApiKey.Location = new System.Drawing.Point(18, 14);
            this.linkLabelApiKey.Name = "linkLabelApiKey";
            this.linkLabelApiKey.Size = new System.Drawing.Size(120, 18);
            this.linkLabelApiKey.TabIndex = 0;
            this.linkLabelApiKey.TabStop = true;
            this.linkLabelApiKey.Text = "API Key";
            this.linkLabelApiKey.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelApiKey_LinkClicked);
            //
            // textBoxApiKey
            //
            this.textBoxApiKey.Location = new System.Drawing.Point(144, 11);
            this.textBoxApiKey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxApiKey.Name = "textBoxApiKey";
            this.textBoxApiKey.PasswordChar = '*';
            this.textBoxApiKey.Size = new System.Drawing.Size(380, 25);
            this.textBoxApiKey.TabIndex = 1;
            //
            // labelRegion
            //
            this.labelRegion.Location = new System.Drawing.Point(18, 48);
            this.labelRegion.Name = "labelRegion";
            this.labelRegion.Size = new System.Drawing.Size(120, 18);
            this.labelRegion.TabIndex = 2;
            this.labelRegion.Text = "Region";
            //
            // comboBoxRegion
            //
            this.comboBoxRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRegion.FormattingEnabled = true;
            this.comboBoxRegion.Location = new System.Drawing.Point(144, 45);
            this.comboBoxRegion.Name = "comboBoxRegion";
            this.comboBoxRegion.Size = new System.Drawing.Size(380, 28);
            this.comboBoxRegion.TabIndex = 3;
            //
            // labelCustomUrl
            //
            this.labelCustomUrl.Location = new System.Drawing.Point(18, 82);
            this.labelCustomUrl.Name = "labelCustomUrl";
            this.labelCustomUrl.Size = new System.Drawing.Size(120, 18);
            this.labelCustomUrl.TabIndex = 4;
            this.labelCustomUrl.Text = "Custom URL";
            //
            // textBoxCustomUrl
            //
            this.textBoxCustomUrl.Location = new System.Drawing.Point(144, 79);
            this.textBoxCustomUrl.Name = "textBoxCustomUrl";
            this.textBoxCustomUrl.Size = new System.Drawing.Size(380, 25);
            this.textBoxCustomUrl.TabIndex = 5;
            //
            // labelModel
            //
            this.labelModel.Location = new System.Drawing.Point(18, 116);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(120, 18);
            this.labelModel.TabIndex = 6;
            this.labelModel.Text = "Model";
            //
            // comboBoxModel
            //
            this.comboBoxModel.FormattingEnabled = true;
            this.comboBoxModel.Location = new System.Drawing.Point(144, 113);
            this.comboBoxModel.Name = "comboBoxModel";
            this.comboBoxModel.Size = new System.Drawing.Size(380, 28);
            this.comboBoxModel.TabIndex = 7;
            //
            // checkAutoSource
            //
            this.checkAutoSource.AutoSize = true;
            this.checkAutoSource.Location = new System.Drawing.Point(144, 151);
            this.checkAutoSource.Name = "checkAutoSource";
            this.checkAutoSource.Size = new System.Drawing.Size(150, 22);
            this.checkAutoSource.TabIndex = 8;
            this.checkAutoSource.Text = "Auto source";
            this.checkAutoSource.UseVisualStyleBackColor = true;
            //
            // labelDomain
            //
            this.labelDomain.Location = new System.Drawing.Point(18, 182);
            this.labelDomain.Name = "labelDomain";
            this.labelDomain.Size = new System.Drawing.Size(120, 18);
            this.labelDomain.TabIndex = 9;
            this.labelDomain.Text = "Domain";
            //
            // textBoxDomain
            //
            this.textBoxDomain.Location = new System.Drawing.Point(144, 179);
            this.textBoxDomain.Multiline = true;
            this.textBoxDomain.Name = "textBoxDomain";
            this.textBoxDomain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDomain.Size = new System.Drawing.Size(380, 68);
            this.textBoxDomain.TabIndex = 10;
            //
            // checkGlossary
            //
            this.checkGlossary.AutoSize = true;
            this.checkGlossary.Location = new System.Drawing.Point(144, 257);
            this.checkGlossary.Name = "checkGlossary";
            this.checkGlossary.Size = new System.Drawing.Size(120, 22);
            this.checkGlossary.TabIndex = 11;
            this.checkGlossary.Text = "Glossary";
            this.checkGlossary.UseVisualStyleBackColor = true;
            //
            // checkTm
            //
            this.checkTm.AutoSize = true;
            this.checkTm.Location = new System.Drawing.Point(144, 285);
            this.checkTm.Name = "checkTm";
            this.checkTm.Size = new System.Drawing.Size(90, 22);
            this.checkTm.TabIndex = 12;
            this.checkTm.Text = "TM";
            this.checkTm.UseVisualStyleBackColor = true;
            //
            // commonBottomControl
            //
            this.commonBottomControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commonBottomControl.ButtonOkState = true;
            this.commonBottomControl.FailedDetailsMsg = null;
            this.commonBottomControl.Location = new System.Drawing.Point(20, 318);
            this.commonBottomControl.Name = "commonBottomControl";
            this.commonBottomControl.Size = new System.Drawing.Size(481, 74);
            this.commonBottomControl.TabIndex = 13;
            //
            // OptionsForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 410);
            this.Controls.Add(this.checkTm);
            this.Controls.Add(this.checkGlossary);
            this.Controls.Add(this.textBoxDomain);
            this.Controls.Add(this.labelDomain);
            this.Controls.Add(this.checkAutoSource);
            this.Controls.Add(this.comboBoxModel);
            this.Controls.Add(this.labelModel);
            this.Controls.Add(this.textBoxCustomUrl);
            this.Controls.Add(this.labelCustomUrl);
            this.Controls.Add(this.comboBoxRegion);
            this.Controls.Add(this.labelRegion);
            this.Controls.Add(this.commonBottomControl);
            this.Controls.Add(this.textBoxApiKey);
            this.Controls.Add(this.linkLabelApiKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Qwen-MT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.LinkLabel linkLabelApiKey;
        private System.Windows.Forms.TextBox textBoxApiKey;
        private System.Windows.Forms.Label labelRegion;
        private System.Windows.Forms.ComboBox comboBoxRegion;
        private System.Windows.Forms.Label labelCustomUrl;
        private System.Windows.Forms.TextBox textBoxCustomUrl;
        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.ComboBox comboBoxModel;
        private System.Windows.Forms.CheckBox checkAutoSource;
        private System.Windows.Forms.Label labelDomain;
        private System.Windows.Forms.TextBox textBoxDomain;
        private System.Windows.Forms.CheckBox checkGlossary;
        private System.Windows.Forms.CheckBox checkTm;
        private CommonBottomControl commonBottomControl;
    }
}
