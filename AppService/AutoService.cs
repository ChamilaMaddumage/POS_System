using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services
{
    public partial class AutoService : Form
    {
        public AutoService()
        {
            InitializeComponent();
        }

        private void AutoService_Load(object sender, EventArgs e)
        {


        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxVehicleNo.Text == "")
                {
                    MessageBox.Show("Please Enter Vehicle No");
                }
                else
                {

                    ProjectConnection Newconnection = new ProjectConnection();
                    Newconnection.Connection_Today();
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = ProjectConnection.conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.CommandText = "dbo.Save_Update_Delete_Service_List";
                    comm.Parameters.AddWithValue("@Vehicle_No", textBoxVehicleNo.Text);
                    comm.Parameters.AddWithValue("@Year", textBoxyear.Text);
                    comm.Parameters.AddWithValue("@Made", textBoxMade.Text);
                    comm.Parameters.AddWithValue("@Model", textBoxModel.Text);
                    comm.Parameters.AddWithValue("@Engine_Oil", textBoxEngineOil.Text);
                    comm.Parameters.AddWithValue("@Transmition", textBoxTransmition.Text);
                    comm.Parameters.AddWithValue("@D_Oil", textBoxDoil.Text);
                    comm.Parameters.AddWithValue("@Break_Oil", textBoxBreakFuel.Text);
                    comm.Parameters.AddWithValue("@PSOil", textBoxPowerSteeringOil.Text);
                    comm.Parameters.AddWithValue("@Air_Filter", textBoxAirFilters.Text);
                    comm.Parameters.AddWithValue("@Carbon_Filters", textBoxCabinFilters.Text);
                    comm.Parameters.AddWithValue("@W_Liquid", textBoxWLiquid.Text);
                    comm.Parameters.AddWithValue("@Other_01", textBoxOther01.Text);
                    comm.Parameters.AddWithValue("@Other_02", textBoxOther02.Text);
                    comm.Parameters.AddWithValue("@Other_03", textBoxOther03.Text);
                    comm.Parameters.AddWithValue("@Other_04", textBoxOther04.Text);
                    comm.Parameters.AddWithValue("@Body_Wash", textBoxBodyWash.Text);
                    comm.Parameters.AddWithValue("@Under_Wash", textBoxUnderWashing.Text);
                    comm.Parameters.AddWithValue("@Complete_Washing", textBoxCompleteWashing.Text);
                    comm.Parameters.AddWithValue("@Interior_Cleaning", textBoxInteriorCleaning.Text);
                    comm.Parameters.AddWithValue("@Other_Services_01", textBoxOtherService01.Text);
                    comm.Parameters.AddWithValue("@Other_Services_02", textBoxOtherService02.Text);
                    comm.Parameters.AddWithValue("@Other_Services_03", textBoxOtherService04.Text);
                    comm.Parameters.AddWithValue("@Other_Services_04", textBoxOtherService05.Text);
                    comm.Parameters.AddWithValue("@Wipers_Blade", textBoxWipersBlade.Text);
                    comm.Parameters.AddWithValue("@Break_Pad_F", textBoxBreakPadF.Text);
                    comm.Parameters.AddWithValue("@Break_Pad_R", textBoxBreakPadRear.Text);
                    comm.Parameters.AddWithValue("@Remark", textBoxReamark.Text);
                    //@Fuel_Injector,@Oil_Filtors,@Petrol_Filtors,@Coolent,@D_Filtors
                    comm.Parameters.AddWithValue("@Fuel_Injector", textBoxFuelInjectorCleaner.Text);
                    comm.Parameters.AddWithValue("@Oil_Filtors", textBoxOilFilters.Text);
                    comm.Parameters.AddWithValue("@Petrol_Filtors", textBoxPetrolFiltors.Text);
                    comm.Parameters.AddWithValue("@Coolent", textBoxCoolent.Text);
                    comm.Parameters.AddWithValue("@D_Filtors", textBoxDFilters.Text);
                    comm.Parameters.AddWithValue("@Date", Convert.ToDateTime(dateTimePicker1.Text));
                    comm.Parameters.AddWithValue("@User_Name", Globlevariable.UserName);
                    comm.ExecuteNonQuery();
                    Clear();
                    Clear();
                    Clear();
                    Clear();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButtonTopUpEOil_CheckedChanged(object sender, EventArgs e)
        {
            textBoxEngineOil.Text = "Top Up";
        }

        private void radioButtonEngineOilReplace_CheckedChanged(object sender, EventArgs e)
        {
            textBoxEngineOil.Text = "Replace";
        }
        private void radioButtonPSOilTopup_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPowerSteeringOil.Text = "Top Up";
        }

        private void radioButtonPSOilReplace_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPowerSteeringOil.Text = "Replace";
        }

        private void radioButtonFuelInjectorCleanerOk_CheckedChanged(object sender, EventArgs e)
        {
            textBoxFuelInjectorCleaner.Text = "Yes";
        }

        private void radioButtonFuelInjectorCleanerNotOK_CheckedChanged(object sender, EventArgs e)
        {
            textBoxFuelInjectorCleaner.Text = "No";
        }

        private void checkBoxReplaceOilFilter_CheckedChanged(object sender, EventArgs e)
        {
            textBoxOilFilters.Text = "Replace";
        }

        private void checkBoxReplacePetrolFilter_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPetrolFiltors.Text = "Replace";
        }

        private void radioButtonWiperBladeOk_CheckedChanged(object sender, EventArgs e)
        {
            textBoxWipersBlade.Text = "Ok";
        }

        private void radioButtonNotOKWiperBlade_CheckedChanged(object sender, EventArgs e)
        {
            textBoxWipersBlade.Text = "Not Ok";
        }

        private void radioButtonChange_CheckedChanged(object sender, EventArgs e)
        {
            textBoxWipersBlade.Text = "Change";
        }

        private void radioButtonCoolentTopUp_CheckedChanged(object sender, EventArgs e)
        {
            textBoxCoolent.Text = "Top Up";
        }

        private void radioButtonCoolentReplace_CheckedChanged(object sender, EventArgs e)
        {
            textBoxCoolent.Text = "Replace";
        }

        private void radioButtonReplaceCabinFilter_CheckedChanged(object sender, EventArgs e)
        {
            textBoxCabinFilters.Text = "Top Up";
        }

        private void radioButtonCabinFiltersReplace_CheckedChanged(object sender, EventArgs e)
        {
            textBoxCabinFilters.Text = "Good";
        }

        private void radioButtonBreakPadFrontGood_CheckedChanged(object sender, EventArgs e)
        {
            textBoxBreakPadF.Text = "Good";
        }

        private void radioButtonBreakPadFrontMedium_CheckedChanged(object sender, EventArgs e)
        {
            textBoxBreakPadF.Text = "Medium";
        }

        private void radioButtonBreakPadFrontBad_CheckedChanged(object sender, EventArgs e)
        {
            textBoxBreakPadF.Text = "Bad";
        }

        private void radioButtonBreakPadRearGood_CheckedChanged(object sender, EventArgs e)
        {
            textBoxBreakPadRear.Text = "Good";
        }

        private void radioButtonBreakPadRearMedium_CheckedChanged(object sender, EventArgs e)
        {
            textBoxBreakPadRear.Text = "Medium";
        }

        private void radioButtonBreakPadRearBad_CheckedChanged(object sender, EventArgs e)
        {
            textBoxBreakPadRear.Text = "Bad";
        }

        private void radioButtonAirFiltersClean_CheckedChanged(object sender, EventArgs e)
        {
            textBoxAirFilters.Text = "Clean";
        }

        private void radioButtonAirFiltersChange_CheckedChanged(object sender, EventArgs e)
        {
            textBoxAirFilters.Text = "Change";
        }

        private void checkBoxDFiltersReplace_CheckedChanged(object sender, EventArgs e)
        {
            textBoxDFilters.Text = "Replace";
        }

        private void radioButtonBreakFuelTopup_CheckedChanged(object sender, EventArgs e)
        {
            textBoxBreakFuel.Text = "Top Up";
        }

        private void radioButtonBreakFuelReplace_CheckedChanged(object sender, EventArgs e)
        {
            textBoxBreakFuel.Text = "Replace";
        }

        private void radioButtonTransmitionTopup_CheckedChanged(object sender, EventArgs e)
        {
            textBoxTransmition.Text = "Top Up";
        }

        private void radioButtonTransmitionReplace_CheckedChanged(object sender, EventArgs e)
        {
            textBoxTransmition.Text = "Replace";

        }

        private void radioButtonDOilTopup_CheckedChanged(object sender, EventArgs e)
        {
            textBoxDoil.Text = "Top Up";
        }

        private void radioButtonDOilReplace_CheckedChanged(object sender, EventArgs e)
        {
            textBoxDoil.Text = "Replace";
        }

        private void checkBoxReplace_CheckedChanged(object sender, EventArgs e)
        {
            textBoxWLiquid.Text = "Replace";
        }

        private void radioButtonUnderWashingYes_CheckedChanged(object sender, EventArgs e)
        {
            textBoxUnderWashing.Text = "Yes";
        }

        private void radioButtonUnderWashingNo_CheckedChanged(object sender, EventArgs e)
        {
            textBoxUnderWashing.Text = "No";
        }

        private void radioButtonInteriorCleaningYes_CheckedChanged(object sender, EventArgs e)
        {
            textBoxInteriorCleaning.Text = "Yes";
        }

        private void radioButtonInteriorCleaningNo_CheckedChanged(object sender, EventArgs e)
        {
            textBoxInteriorCleaning.Text = "No";
        }

        private void radioButtonCompleteWashingYes_CheckedChanged(object sender, EventArgs e)
        {
            textBoxCompleteWashing.Text = "Yes";
        }

        private void radioButtonCompleteWashingNo_CheckedChanged(object sender, EventArgs e)
        {
            textBoxCompleteWashing.Text = "No";
        }

        private void radioButtonBodyWashYes_CheckedChanged(object sender, EventArgs e)
        {
            textBoxBodyWash.Text = "Yes";
        }

        private void radioButtonBodywashNo_CheckedChanged(object sender, EventArgs e)
        {
            textBoxBodyWash.Text = "No";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
            Clear();
            Clear();
            Clear();
            Clear();
        }
        public void Clear()
        {
            radioButton3.Checked = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            textBoxPetrolFiltors.Clear();
            textBoxFuelInjectorCleaner.Clear();
            textBoxOilFilters.Clear();
            textBoxCoolent.Clear();
            textBoxVehicleNo.Clear();
            textBoxyear.Clear();
            textBoxModel.Clear();
            textBoxEngineOil.Clear();
            textBoxTransmition.Clear();
            textBoxDoil.Clear();
            textBoxBreakFuel.Clear();
            textBoxPowerSteeringOil.Clear();
            textBoxAirFilters.Clear();
            textBoxCabinFilters.Clear();
            textBoxWLiquid.Clear();
            textBoxOther01.Clear();
            textBoxOther02.Clear();
            textBoxOther03.Clear();
            textBoxOther04.Clear();
            textBoxBodyWash.Clear();
            textBoxUnderWashing.Clear();
            textBoxCompleteWashing.Clear();
            textBoxInteriorCleaning.Clear();
            textBoxOtherService01.Clear();
            textBoxOtherService02.Clear();
            textBoxOtherService04.Clear();
            textBoxOtherService05.Clear();
            textBoxWipersBlade.Clear();
            textBoxBreakPadF.Clear();
            textBoxBreakPadRear.Clear();
            textBoxMade.Clear();
            textBoxReamark.Clear();

            radioButtonBodywashNo.Checked = false;
            radioButtonBodyWashYes.Checked = false;
            radioButtonCompleteWashingNo.Checked = false;
            radioButtonCompleteWashingYes.Checked = false;
            radioButtonInteriorCleaningNo.Checked = false;
            radioButtonInteriorCleaningYes.Checked = false;
            radioButtonUnderWashingNo.Checked = false;
            radioButtonUnderWashingYes.Checked = false;
            checkBoxReplace.Checked = false;
            radioButtonDOilReplace.Checked = false;
            radioButtonDOilTopup.Checked = false;
            radioButtonTransmitionReplace.Checked = false;
            radioButtonTransmitionTopup.Checked = false;
            radioButtonBreakFuelReplace.Checked = false;
            radioButtonBreakFuelTopup.Checked = false;
            checkBoxDFiltersReplace.Checked = false;
            radioButtonAirFiltersChange.Checked = false;
            radioButtonAirFiltersClean.Checked = false;
            radioButtonBreakPadRearBad.Checked = false;
            radioButtonBreakPadRearMedium.Checked = false;
            radioButtonBreakPadRearGood.Checked = false;
            radioButtonBreakPadFrontBad.Checked = false;
            radioButtonBreakPadFrontMedium.Checked = false;
            radioButtonBreakPadFrontGood.Checked = false;
            radioButtonCabinFiltersReplace.Checked = false;
            radioButtonReplaceCabinFilter.Checked = false;
            radioButtonCoolentReplace.Checked = false;
            radioButtonCoolentTopUp.Checked = false;
            radioButtonChange.Checked = false;
            radioButtonNotOKWiperBlade.Checked = false;
            radioButtonWiperBladeOk.Checked = false;
            checkBoxReplacePetrolFilter.Checked = false;
            checkBoxReplaceOilFilter.Checked = false;
            radioButtonFuelInjectorCleanerNotOK.Checked = false;
            radioButtonFuelInjectorCleanerOk.Checked = false;
            radioButtonPSOilReplace.Checked = false;
            radioButtonPSOilTopup.Checked = false;
            radioButtonEngineOilReplace.Checked = false;
            radioButtonTopUpEOil.Checked = false;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBoxCoolent.Text = "Yes";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBoxCoolent.Text = "Bad";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBoxOther04.Text = "Checked";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBoxOther04.Text = "Not Checked";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBoxCabinFilters.Text = "Bad";
        }
    }
}
