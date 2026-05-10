using MultiSupplierMTPlugin;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Providers.QwenMT.LocalizedKey;

namespace MultiSupplierMTPlugin.Providers.QwenMT
{
    partial class OptionsForm : Form
    {
        private readonly Service _service;
        private readonly GeneralSettings _generalSettings;
        private readonly SecureSettings _secureSettings;
        private readonly MultiSupplierMTGeneralSettings _mtGeneralSettings;
        private readonly MultiSupplierMTSecureSettings _mtSecureSettings;

        public OptionsForm(Service service, GeneralSettings generalSettings, SecureSettings secureSettings,
            MultiSupplierMTGeneralSettings mtGeneralSettings, MultiSupplierMTSecureSettings mtSecureSettings)
        {
            InitializeComponent();

            _service = service;
            _generalSettings = generalSettings;
            _secureSettings = secureSettings;
            _mtGeneralSettings = mtGeneralSettings;
            _mtSecureSettings = mtSecureSettings;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Localized();
            LoadOptions();
            BindOptionsChangedEvent();
        }

        private void Localized()
        {
            Text = LLH.G(LLK.FormTitle);
            linkLabelApiKey.Text = LLH.G(LLK.LinkLabelApiKey);
            labelRegion.Text = LLH.G(LLK.LabelRegion);
            labelCustomUrl.Text = LLH.G(LLK.LabelCustomUrl);
            labelModel.Text = LLH.G(LLK.LabelModel);
            checkAutoSource.Text = LLH.G(LLK.CheckAutoSource);
            labelDomain.Text = LLH.G(LLK.LabelDomain);
            checkGlossary.Text = LLH.G(LLK.CheckGlossary);
            checkTm.Text = LLH.G(LLK.CheckTm);
        }

        private void LoadOptions()
        {
            textBoxApiKey.Text = _secureSettings.ApiKey;

            comboBoxRegion.Items.Clear();
            comboBoxRegion.Items.Add(new RegionItem("Beijing", QwenMtEndpoints.Beijing));
            comboBoxRegion.Items.Add(new RegionItem("Singapore", QwenMtEndpoints.Singapore));
            comboBoxRegion.Items.Add(new RegionItem("US (Virginia)", QwenMtEndpoints.USVirginia));
            comboBoxRegion.Items.Add(new RegionItem("Custom", null));

            SelectRegionByBaseUrl(_generalSettings.BaseURL ?? QwenMtEndpoints.Beijing);
            textBoxCustomUrl.Text = _generalSettings.BaseURL;

            comboBoxModel.Items.Clear();
            foreach (var m in new[] { "qwen-mt-plus", "qwen-mt-flash", "qwen-mt-lite", "qwen-mt-turbo", "qwen-mt-lite-us" })
                comboBoxModel.Items.Add(m);
            comboBoxModel.Text = string.IsNullOrEmpty(_generalSettings.Model) ? "qwen-mt-plus" : _generalSettings.Model;

            checkAutoSource.Checked = _generalSettings.AutoSourceLanguage;
            textBoxDomain.Text = _generalSettings.DomainHint ?? string.Empty;
            checkGlossary.Checked = _generalSettings.SendGlossaryTerms;
            checkTm.Checked = _generalSettings.SendTmList;

            commonBottomControl.Init(this, _generalSettings.Checked, _service.ApiDocLink, linkLabelCheck_LinkClicked, Controls);
            UpdateCustomUrlVisibility();
        }

        private void SelectRegionByBaseUrl(string baseUrl)
        {
            if (string.IsNullOrEmpty(baseUrl))
                baseUrl = QwenMtEndpoints.Beijing;

            for (int i = 0; i < comboBoxRegion.Items.Count; i++)
            {
                var item = comboBoxRegion.Items[i] as RegionItem;
                if (item?.Url != null && string.Equals(item.Url.TrimEnd('/'), baseUrl.TrimEnd('/'), StringComparison.OrdinalIgnoreCase))
                {
                    comboBoxRegion.SelectedIndex = i;
                    return;
                }
            }

            comboBoxRegion.SelectedIndex = comboBoxRegion.Items.Count - 1;
            textBoxCustomUrl.Text = baseUrl;
        }

        private string GetEffectiveBaseUrl()
        {
            var sel = comboBoxRegion.SelectedItem as RegionItem;
            if (sel?.Url != null)
                return sel.Url.TrimEnd('/');
            return (textBoxCustomUrl.Text ?? string.Empty).Trim().TrimEnd('/');
        }

        private void UpdateCustomUrlVisibility()
        {
            var custom = comboBoxRegion.SelectedIndex == comboBoxRegion.Items.Count - 1;
            labelCustomUrl.Visible = custom;
            textBoxCustomUrl.Visible = custom;
        }

        private void BindOptionsChangedEvent()
        {
            void onChanged(object sender, EventArgs e)
            {
                var baseUrl = GetEffectiveBaseUrl();
                if (_secureSettings.ApiKey != textBoxApiKey.Text ||
                    _generalSettings.BaseURL != baseUrl ||
                    _generalSettings.Model != comboBoxModel.Text.Trim() ||
                    _generalSettings.AutoSourceLanguage != checkAutoSource.Checked ||
                    (_generalSettings.DomainHint ?? "") != textBoxDomain.Text ||
                    _generalSettings.SendGlossaryTerms != checkGlossary.Checked ||
                    _generalSettings.SendTmList != checkTm.Checked)
                {
                    commonBottomControl.ButtonOkState = false;
                }
                else
                {
                    commonBottomControl.ButtonOkState = _generalSettings.Checked;
                }
            }

            textBoxApiKey.TextChanged += onChanged;
            textBoxCustomUrl.TextChanged += onChanged;
            comboBoxRegion.SelectedIndexChanged += (s, ev) =>
            {
                UpdateCustomUrlVisibility();
                onChanged(s, ev);
            };
            comboBoxModel.TextChanged += onChanged;
            checkAutoSource.CheckedChanged += onChanged;
            textBoxDomain.TextChanged += onChanged;
            checkGlossary.CheckedChanged += onChanged;
            checkTm.CheckedChanged += onChanged;
        }

        private async Task linkLabelCheck_LinkClicked()
        {
            await _service.Check(new Options(
                new GeneralSettings
                {
                    BaseURL = GetEffectiveBaseUrl(),
                    Model = comboBoxModel.Text.Trim(),
                    AutoSourceLanguage = checkAutoSource.Checked,
                    DomainHint = textBoxDomain.Text,
                    SendGlossaryTerms = checkGlossary.Checked,
                    SendTmList = checkTm.Checked,
                    Checked = true
                },
                new SecureSettings { ApiKey = textBoxApiKey.Text }));
        }

        private void linkLabelApiKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(_service.ApiKeyLink);
            }
            catch
            {
            }
        }

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                return;

            _secureSettings.ApiKey = textBoxApiKey.Text;
            _generalSettings.BaseURL = GetEffectiveBaseUrl();
            _generalSettings.Model = comboBoxModel.Text.Trim();
            _generalSettings.AutoSourceLanguage = checkAutoSource.Checked;
            _generalSettings.DomainHint = textBoxDomain.Text?.Trim() ?? string.Empty;
            _generalSettings.SendGlossaryTerms = checkGlossary.Checked;
            _generalSettings.SendTmList = checkTm.Checked;
            _generalSettings.Checked = true;
        }

        private sealed class RegionItem
        {
            public RegionItem(string name, string url)
            {
                Name = name;
                Url = url;
            }

            public string Name { get; }
            public string Url { get; }

            public override string ToString() => Name;
        }
    }
}
