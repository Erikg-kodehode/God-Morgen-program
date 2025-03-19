using System;
using System.Drawing;
using System.Windows.Forms;

public class GreetingForm : Form
{
    private TextBox nameTextBox;
    private ComboBox timeChoiceBox;
    private NumericUpDown hourInput;
    private NumericUpDown minuteInput;
    private Button submitButton;
    private Label resultLabel;

    public GreetingForm()
    {
        Text = "God Morgen Program";
        Size = new Size(400, 300);
        StartPosition = FormStartPosition.CenterScreen;
        Icon = new Icon("Favicon.ico");

        Label nameLabel = new Label { Text = "Hva heter du?", Location = new Point(20, 20), AutoSize = true };
        nameTextBox = new TextBox { Location = new Point(150, 20), Width = 200 };

        Label timeChoiceLabel = new Label { Text = "Bruke nåværende tid eller velge?", Location = new Point(20, 60), AutoSize = true };
        timeChoiceBox = new ComboBox { Location = new Point(250, 60), Width = 100, DropDownStyle = ComboBoxStyle.DropDownList };
        timeChoiceBox.Items.AddRange(new string[] { "Nå", "Egen" });
        timeChoiceBox.SelectedIndex = 0;
        timeChoiceBox.SelectedIndexChanged += TimeChoiceChanged;

        Label hourLabel = new Label { Text = "Time (0-23):", Location = new Point(20, 100), AutoSize = true };
        hourInput = new NumericUpDown { Location = new Point(150, 100), Width = 50, Minimum = 0, Maximum = 23, Enabled = false };

        Label minuteLabel = new Label { Text = "Minutter (0-59):", Location = new Point(20, 140), AutoSize = true };
        minuteInput = new NumericUpDown { Location = new Point(150, 140), Width = 50, Minimum = 0, Maximum = 59, Enabled = false };

        submitButton = new Button { Text = "Få hilsen", Location = new Point(150, 180), Width = 100 };
        submitButton.Click += ShowGreeting;

        resultLabel = new Label { Text = "", Location = new Point(20, 220), AutoSize = true, ForeColor = Color.Blue };

        Controls.Add(nameLabel);
        Controls.Add(nameTextBox);
        Controls.Add(timeChoiceLabel);
        Controls.Add(timeChoiceBox);
        Controls.Add(hourLabel);
        Controls.Add(hourInput);
        Controls.Add(minuteLabel);
        Controls.Add(minuteInput);
        Controls.Add(submitButton);
        Controls.Add(resultLabel);
    }

    private void TimeChoiceChanged(object sender, EventArgs e)
    {
        bool enableTimeSelection = timeChoiceBox.SelectedIndex == 1;
        hourInput.Enabled = enableTimeSelection;
        minuteInput.Enabled = enableTimeSelection;
    }

    private void ShowGreeting(object sender, EventArgs e)
    {
        string name = string.IsNullOrWhiteSpace(nameTextBox.Text) ? "Bruker" : nameTextBox.Text;
        DateTime now = DateTime.Now;
        int hour = now.Hour;
        int minute = now.Minute;

        if (timeChoiceBox.SelectedIndex == 1)
        {
            hour = (int)hourInput.Value;
            minute = (int)minuteInput.Value;
        }

        string greeting = GreetingService.GetGreeting(hour);
        resultLabel.Text = $"{greeting}, {name}! Klokken er {hour:D2}:{minute:D2}.";
    }
}
