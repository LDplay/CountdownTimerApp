namespace WinFormsApp10
{
    public partial class Form1 : Form
    {
        private DateTime targetDate;
        private System.Windows.Forms.Timer countdownTimer;
        private DateTime startTime;

        private Label countdownLabel;

        public Form1()
        {
            InitializeComponent();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            targetDate = new DateTime(2023, 12, 30);

            countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Interval = 1000;
            countdownTimer.Tick += CountdownTimer_Tick;
            countdownTimer.Start();

            startTime = DateTime.Now;

            countdownLabel = new Label();
            countdownLabel.AutoSize = true;
            countdownLabel.Location = new System.Drawing.Point(200, 200);
            Controls.Add(countdownLabel);

            UpdateElapsedTime();
            UpdateCountdown();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            UpdateElapsedTime();
            UpdateCountdown();
        }

        private void UpdateCountdown()
        {
            TimeSpan timeLeft = targetDate - DateTime.Now;

            if (timeLeft.TotalMilliseconds <= 0)
            {
                countdownTimer.Stop();
                countdownLabel.Text = "Время вышло!";
            }
            else
            {
                countdownLabel.Text = $"До {targetDate.ToString("dd.MM.yyyy")} осталось: {timeLeft.Days} дней, {timeLeft.Hours} часов, {timeLeft.Minutes} минут, {timeLeft.Seconds} секунд";
            }
        }

        private void UpdateElapsedTime()
        {
            TimeSpan elapsedTime = DateTime.Now - startTime;
            Text = $"Прошло времени: {elapsedTime.TotalMilliseconds} миллисекунд";
        }
    }
}

