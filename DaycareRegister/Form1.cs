using System.Windows.Forms;

namespace DaycareRegister
{
    public partial class Child_Registration_Form : Form
    {
        bool imageSet;
        public Child_Registration_Form()
        {
            InitializeComponent();
        }
        private string GroupChild(int age)
        {
            string groupName = null;
            if (age >= 1 && age <= 3)
            {
                groupName = "Little star";
            }
            else if (age >= 3 && age < 4)
            {
                groupName = "Little Angel";
            }
            else if (age >= 4 && age < 5)
            {
                groupName = "Little future";
            }
            return groupName;
        }
        private void btn_upload_Click(object sender, System.EventArgs e)
        {
            loadImage.DefaultExt = "jpg";
            loadImage.Filter = "JPEG file|*.jpg|PNG File|*.png";
            if (loadImage.ShowDialog() != DialogResult.OK)
            {
                loadImage.Dispose();
                return;
            }
            // openFileDialog1.ShowDialog();
            string path = loadImage.FileName;
            PhotoBox.Image = System.Drawing.Image.FromFile(path);
            imageSet = true;
            label_photoWarning.Visible = false;
        }

        private void Child_Registration_Form_Load(object sender, System.EventArgs e)
        {

        }

        private void fnBox_Validated(object sender, System.EventArgs e)
        {
            if (fnBox.Text == string.Empty)
            {
                MessageBox.Show("First Name can not be empty.");
            }
        }

        private void lnBox_Validated(object sender, System.EventArgs e)
        {
            if (lnBox.Text == string.Empty)
            {
                MessageBox.Show("Last Name can not be empty.");
            }
        }

        private void dobBox_Validated(object sender, System.EventArgs e)
        {
            int age = (int)((System.DateTime.Today.Date - dobBox.Value.Date).TotalDays / 365.25);
            if (age > 5 || age < 1)
            {
                MessageBox.Show("only age betwwen 1 and 5 years old can be enrolled.");
                dobBox.Value = System.DateTime.Today.Date;
            }
        }

        private void sinBox_Validated(object sender, System.EventArgs e)
        {
            if (sinBox.Text == string.Empty)
            {
                MessageBox.Show("Sin Number can not be empty.");
            }
        }

        private void f_fnBox_Validated(object sender, System.EventArgs e)
        {
            if (f_fnBox.Text == string.Empty)
            {
                MessageBox.Show("First Name can not be empty.");
            }
        }

        private void f_lnBox_Validated(object sender, System.EventArgs e)
        {
            if (f_lnBox.Text == string.Empty)
            {
                MessageBox.Show("Last Name can not be empty.");
            }
        }

        private void f_phoneNumberBox_Validated(object sender, System.EventArgs e)
        {
            if (f_phoneNumberBox.Text == string.Empty)
            {
                MessageBox.Show("Phone number can not be empty.");
            }
        }

        private void m_fnBox_Validated(object sender, System.EventArgs e)
        {
            if (m_fnBox.Text == string.Empty)
            {
                MessageBox.Show("First Name can not be empty.");
            }
        }

        private void m_lnBox_Validated(object sender, System.EventArgs e)
        {
            if (m_lnBox.Text == string.Empty)
            {
                MessageBox.Show("Last name can not be empty");
            }
        }

        private void m_phoneNumberBox_Validated(object sender, System.EventArgs e)
        {
            if (m_phoneNumberBox.Text == string.Empty)
            {
                MessageBox.Show("phone number can not be empty");
            }
        }

        private void btn_save_Click(object sender, System.EventArgs e)
        {
            bool save = true;
            //validation for each child's field:
            if (fnBox.Text == string.Empty)
            {
                label_fn.ForeColor = System.Drawing.Color.Red;
                save = false;
            }
            else
            {
                label_fn.ForeColor = DefaultForeColor;
            }
            if (lnBox.Text == string.Empty)
            {
                label_ln.ForeColor = System.Drawing.Color.Red;
                save = false;
            }
            else
            {
                label_ln.ForeColor = DefaultForeColor;
            }
            if (dobBox.Value.Date == System.DateTime.Today.Date)
            {
                label_dob.ForeColor = System.Drawing.Color.Red;
                save = false;
            }
            else
            {
                label_dob.ForeColor = DefaultForeColor;
            }
            if (btn_f.Checked == false && btn_m.Checked == false)
            {
                label_gender.ForeColor = System.Drawing.Color.Red;
                save = false;
            }
            else
            {
                label_gender.ForeColor = DefaultForeColor;
            }
            if (sinBox.Text == string.Empty)
            {
                label_sin.ForeColor = System.Drawing.Color.Red;
                save = false;
            }
            else
            {
                label_sin.ForeColor = DefaultForeColor;
            }
            //validation for father fields:
            if (f_fnBox.Text == string.Empty)
            {
                label_f_fn.ForeColor = System.Drawing.Color.Red;
                save = false;
            }
            else
            {
                label_f_fn.ForeColor = DefaultForeColor;
            }
            if (f_lnBox.Text == string.Empty)
            {
                label_f_ln.ForeColor = System.Drawing.Color.Red;
                save = false;
            }
            else
            {
                label_f_ln.ForeColor = DefaultForeColor;
            }
            if (f_phoneNumberBox.Text == string.Empty)
            {
                label_f_phone.ForeColor = System.Drawing.Color.Red;
                save = false;
            }
            else
            {
                label_f_phone.ForeColor = DefaultForeColor;
            }
            //validation for mother fields:
            if (m_fnBox.Text == string.Empty)
            {
                label_m_fn.ForeColor = System.Drawing.Color.Red;
                save = false;
            }
            else
            {
                label_m_fn.ForeColor = DefaultForeColor;
            }
            if (m_lnBox.Text == string.Empty)
            {
                label_m_ln.ForeColor = System.Drawing.Color.Red;
                save = false;
            }
            else
            {
                label_m_ln.ForeColor = DefaultForeColor;
            }
            if (m_phoneNumberBox.Text == string.Empty)
            {
                label_m_phone.ForeColor = System.Drawing.Color.Red;
                save = false;
            }
            else
            {
                label_m_phone.ForeColor = DefaultForeColor;
            }


            //------------------------------
            //save file
            if (save == true)
            {
                //remove warning for all input if all filled correctly
                label_warning.Visible = false;
                //photo warning setting
                if (imageSet == true)
                {
                    label_photoWarning.Visible = false;
                    string[] data = {
                        label_fn.Text + fnBox.Text, label_ln.Text + lnBox.Text, label_dob.Text + dobBox.Value.ToShortDateString(),
                        label_gender.Text + (btn_m.Checked == true ? "M" : "F"), label_sin.Text + sinBox.Text,label_allergies.Text + allergiesBox.Text,
                        "Group: " + GroupChild((int)((System.DateTime.Today.Date - dobBox.Value.Date).TotalDays / 365.25)),
                        "-----Father or Guardian information-----: ",
                        label_f_fn.Text+ f_fnBox.Text,label_f_ln.Text + f_lnBox.Text,label_f_phone.Text + f_phoneNumberBox.Text,label_f_email.Text + f_emailBox.Text,label_f_strAdd.Text +
                        f_address.Text, label_f_city.Text + f_cityBox.Text, label_f_province.Text + f_provinceBox.Text, label_f_postcode.Text + f_postCodeBox.Text,
                        "------Mother or Guardian information-----: ",
                        label_m_fn.Text+ m_fnBox.Text,label_m_ln.Text + m_lnBox.Text,label_m_phone.Text + m_phoneNumberBox.Text,label_m_email.Text + m_emailBox.Text,label_m_strAdd.Text + m_addressBox.Text, label_m_city.Text + m_cityBox.Text, label_m_province.Text + m_provinceBox.Text, label_m_postcode.Text + m_postCodeBox.Text
                        };
                    saveTxt.DefaultExt = "txt";
                    saveTxt.Filter = "TXT file|*.txt";
                    if (saveTxt.ShowDialog() != DialogResult.OK)
                    {
                        saveTxt.Dispose();
                        return;
                    }
                    string filePath = saveTxt.FileName;
                    System.IO.File.WriteAllLines(filePath, data);
                    PhotoBox.Image.Save(filePath.Replace(".txt", ".jpg"));
                    MessageBox.Show("Your profile and photo is Saved!" + '\n' + "Welcome to our daycare, your child will be in Group: " + GroupChild((int)((System.DateTime.Today.Date - dobBox.Value.Date).TotalDays / 365.25)));
                }
                else
                {
                    label_photoWarning.ForeColor = System.Drawing.Color.Red;
                    label_photoWarning.Visible = true;

                }

                /*
                
                    pictureBox_photo.Image.Save(filePath.Replace(".txt", ".jpg"));
                    MessageBox.Show("your file and photo is saved.");
                 
                 
                 */


            }
            else
            {
                label_warning.Visible = true;
                label_warning.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btn_reset_Click(object sender, System.EventArgs e)
        {
            //remove label warning and label red color
            label_warning.Visible = false;
            foreach (Control x in this.Controls)
            {
                if (x is Label)
                {
                    x.ForeColor = DefaultForeColor;
                }
            }
            foreach (Control x in fatherBox.Controls)
            {
                if (x is Label)
                {
                    x.ForeColor = DefaultForeColor;
                }
            }
            foreach (Control x in motherBox.Controls)
            {
                if (x is Label)
                {
                    x.ForeColor = DefaultForeColor;
                }
            }
            // clear textbox content and other input
            PhotoBox.Image = DaycareRegister.Properties.Resources.avatar2;
            imageSet = false;
            dobBox.Value = System.DateTime.Today.Date;
            btn_f.Checked = false; btn_m.Checked = false;
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    x.Text = string.Empty;
                }
            }
            foreach (Control x in fatherBox.Controls)
            {
                if (x is TextBox)
                {
                    x.Text = string.Empty;
                }
            }
            foreach (Control x in motherBox.Controls)
            {
                if (x is TextBox)
                {
                    x.Text = string.Empty;
                }
            }


        }

        private void btn_load_Click(object sender, System.EventArgs e)
        {
            loadTxt.DefaultExt = "txt";
            loadTxt.DefaultExt = "txt";
            loadTxt.Filter = "TXT file|*.txt";
            if (loadTxt.ShowDialog() != DialogResult.OK)
            {
                loadTxt.Dispose();
                return;
            }
            string path = loadTxt.FileName;
            string[] dataRead = System.IO.File.ReadAllLines(path);
            //child information
            fnBox.Text = dataRead[0].Split(':')[1].Trim();
            lnBox.Text = dataRead[1].Split(':')[1].Trim();
            dobBox.Value = System.Convert.ToDateTime(dataRead[2].Split(':')[1].Trim());
            switch (dataRead[3].Split(':')[1].Trim())
            {
                case "M":
                    btn_m.Checked = true;
                    break;
                case "F":
                    btn_f.Checked = true;
                    break;
            }
            sinBox.Text = dataRead[4].Split(':')[1].Trim();
            allergiesBox.Text = dataRead[5].Split(':')[1].Trim();
            //father information
            f_fnBox.Text = dataRead[8].Split(':')[1].Trim();
            f_lnBox.Text = dataRead[9].Split(':')[1].Trim();
            f_phoneNumberBox.Text = dataRead[10].Split(':')[1].Trim();
            f_emailBox.Text = dataRead[11].Split(':')[1].Trim();
            f_address.Text = dataRead[12].Split(':')[1].Trim();
            f_cityBox.Text = dataRead[13].Split(':')[1].Trim();
            f_provinceBox.Text = dataRead[14].Split(':')[1].Trim();
            f_postCodeBox.Text = dataRead[15].Split(':')[1].Trim();
            //mother information
            m_fnBox.Text = dataRead[17].Split(':')[1].Trim();
            m_lnBox.Text = dataRead[18].Split(':')[1].Trim();
            m_phoneNumberBox.Text = dataRead[19].Split(':')[1].Trim();
            m_emailBox.Text = dataRead[20].Split(':')[1].Trim();
            m_addressBox.Text = dataRead[21].Split(':')[1].Trim();
            m_cityBox.Text = dataRead[22].Split(':')[1].Trim();
            m_provinceBox.Text = dataRead[23].Split(':')[1].Trim();
            m_postCodeBox.Text = dataRead[24].Split(':')[1].Trim();
            imageSet = false;
            /*
             loadFileDialog.DefaultExt = "txt";
            loadFileDialog.DefaultExt = "txt";
            loadFileDialog.Filter = "TXT file|*.txt";
            if (loadFileDialog.ShowDialog() != DialogResult.OK)
            {
                loadFileDialog.Dispose();
                return;
            }
            string path = loadFileDialog.FileName;
            string[] dataRead = System.IO.File.ReadAllLines(path);
            txtb_fn.Text = dataRead[0].Split(':')[1].Trim();
            txtb_ln.Text = dataRead[1].Split(':')[1].Trim();
            switch (dataRead[2].Split(':')[1].Trim())
            {
                case "Male":
                    radioButton1.Checked = true;
                    break;
                case "Female":
                    radioButton2.Checked = true;
                    break;
            }
            dateTimePicker.Value = Convert.ToDateTime(dataRead[3].Split(':')[1].Trim());
            txtb_add.Text = dataRead[4].Split(':')[1].Trim();
            txtb_city.Text = dataRead[5].Split(':')[1].Trim();
            txtb_province.Text = dataRead[6].Split(':')[1].Trim();
            txtb_pc.Text = dataRead[7].Split(':')[1].Trim();
            txtb_phone.Text = dataRead[8].Split(':')[1].Trim();
            txtb_height.Text = dataRead[9].Split(':')[1].Trim();
            txtb_weight.Text = dataRead[10].Split(':')[1].Trim();
            yrs_experience.Value = decimal.Parse(dataRead[11].Split(':')[1].Trim());
            txtb_cat.Text = dataRead[12].Split(':')[1].Trim();
            pictureBox_photo.Image = Image.FromHbitmap(Properties.Resources.avatar.GetHbitmap());
            txt_gender_reminder.Text = "";
            txt_age.Text = "";
             
             */
        }
    }
}
