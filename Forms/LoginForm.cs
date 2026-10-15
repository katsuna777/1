using DemoExam2026.Models;
using DemoExam2026.Services;

namespace DemoExam2026.Forms;

public sealed class LoginForm : Form
{
    private readonly AuthService _authService = new();
    private readonly TextBox _txtLogin = new();
    private readonly TextBox _txtPassword = new();

    public LoginForm()
    {
        Text = "Авторизация обувного магазина";
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ClientSize = new Size(420, 300);
        Font = new Font("Segoe UI", 10F);

        var title = new Label
        {
            Text = "Обувной магазин",
            Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold),
            AutoSize = true,
            Location = new Point(32, 24)
        };
        var subtitle = new Label
        {
            Text = "Войдите в свою учётную запись",
            AutoSize = true,
            ForeColor = Color.DimGray,
            Location = new Point(34, 62)
        };

        var loginLabel = new Label { Text = "Логин", AutoSize = true, Location = new Point(36, 105) };
        _txtLogin.Name = "txtLogin";
        _txtLogin.Location = new Point(36, 128);
        _txtLogin.Size = new Size(348, 27);
        _txtLogin.TabIndex = 0;

        var passwordLabel = new Label { Text = "Пароль", AutoSize = true, Location = new Point(36, 164) };
        _txtPassword.Name = "txtPassword";
        _txtPassword.Location = new Point(36, 187);
        _txtPassword.Size = new Size(348, 27);
        _txtPassword.UseSystemPasswordChar = true;
        _txtPassword.TabIndex = 1;

        var btnLogin = new Button
        {
            Name = "btnLogin",
            Text = "Войти",
            Location = new Point(36, 235),
            Size = new Size(166, 38),
            TabIndex = 2
        };
        btnLogin.Click += btnLogin_Click;

        var btnGuest = new Button
        {
            Name = "btnGuest",
            Text = "Войти как гость",
            Location = new Point(218, 235),
            Size = new Size(166, 38),
            TabIndex = 3
        };
        btnGuest.Click += btnGuest_Click;

        AcceptButton = btnLogin;
        Controls.AddRange([title, subtitle, loginLabel, _txtLogin, passwordLabel, _txtPassword, btnLogin, btnGuest]);
    }

    private void btnLogin_Click(object? sender, EventArgs e)
    {
        var login = _txtLogin.Text.Trim();
        var password = _txtPassword.Text;

        if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show("Введите логин и пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var user = _authService.Authenticate(login, password);
            if (user is null)
            {
                MessageBox.Show("Неверный логин или пароль.", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OpenMainForm(user);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Не удалось подключиться к базе данных. Проверьте, что MySQL запущен и база DemoExam2026 доступна.\n\nПодробности: {ex.Message}",
                "Ошибка подключения",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void btnGuest_Click(object? sender, EventArgs e) => OpenMainForm(null);

    private void OpenMainForm(User? user)
    {
        Hide();
        using var mainForm = new MainForm(user);
        mainForm.ShowDialog(this);
        Show();
        _txtPassword.Clear();
        _txtLogin.Focus();
    }
}
