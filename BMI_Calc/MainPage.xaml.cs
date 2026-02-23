namespace BMI_Calc;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void btnCalculate_Click(object sender, EventArgs e)
    {
        try
        {
            double weight = Convert.ToDouble(txtWeight.Text);
            double feet = Convert.ToDouble(txtFeet.Text);
            double inches = Convert.ToDouble(txtInches.Text);

            // Convert feet and inches to meters
            double totalInches = (feet * 12) + inches;
            double heightInMeters = totalInches * 0.0254;

            double bmi = weight / (heightInMeters * heightInMeters);

            lblResult.Text = $"Your BMI is: {Math.Round(bmi, 2)}";

            if (bmi < 18.5)
                lblStatus.Text = "Status: Underweight";
            else if (bmi < 25)
                lblStatus.Text = "Status: Normal weight";
            else if (bmi < 30)
                lblStatus.Text = "Status: Overweight";
            else
                lblStatus.Text = "Status: Obese";
        }
        catch (FormatException)
        {
            await DisplayAlertAsync("Invalid Input", "Please enter valid numeric values.", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Error", ex.Message, "OK");
        }
    }
}