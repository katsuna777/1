using DemoExam2026.Models;

namespace DemoExam2026.Forms;

public sealed class MainForm : Form
{
    private readonly User? _user;
    private readonly Label _lblUser = new();
    private readonly Label _lblRole = new();
    private readonly Label _lblCapabilities = new();

    public MainForm(User? user)
    {
        _user = user;

        Text = "Обувной магазин";
        StartPosition = FormStartPosition.CenterParent;
        MinimumSize = new Size(680, 440);
        Size = new Size(800, 520);
        Font = new Font("Segoe UI", 10F);

        var header = new Panel
        {
            Dock = DockStyle.Top,
            Height = 82,
            BackColor = Color.FromArgb(35, 55, 75),
            Padding = new Padding(24, 14, 24, 14)
        };
        var title = new Label
        {
            Text = "Обувной магазин",
            ForeColor = Color.White,
            Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold),
            AutoSize = true,
            Location = new Point(22, 20)
        };
        _lblUser.AutoSize = true;
        _lblUser.ForeColor = Color.White;
        _lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _lblUser.Location = new Point(520, 30);
        header.Controls.Add(title);
        header.Controls.Add(_lblUser);

        var body = new Panel { Dock = DockStyle.Fill, Padding = new Padding(32) };
        var welcome = new Label
        {
            Text = "Добро пожаловать",
            Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold),
            AutoSize = true,
            Location = new Point(32, 28)
        };
        _lblRole.AutoSize = true;
        _lblRole.ForeColor = Color.FromArgb(60, 90, 120);
        _lblRole.Location = new Point(34, 72);
        _lblCapabilities.AutoSize = true;
        _lblCapabilities.MaximumSize = new Size(660, 0);
        _lblCapabilities.Location = new Point(34, 116);

        var btnLogout = new Button
        {
            Name = "btnLogout",
            Text = "Выйти",
            Size = new Size(120, 38),
            Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
            Location = new Point(620, 340)
        };
        btnLogout.Click += btnLogout_Click;

        body.Controls.AddRange([welcome, _lblRole, _lblCapabilities, btnLogout]);
        Controls.Add(body);
        Controls.Add(header);

        ConfigureInterface();
        Resize += (_, _) => btnLogout.Location = new Point(body.ClientSize.Width - btnLogout.Width - 32, body.ClientSize.Height - btnLogout.Height - 24);
        Shown += (_, _) => btnLogout.Location = new Point(body.ClientSize.Width - btnLogout.Width - 32, body.ClientSize.Height - btnLogout.Height - 24);
    }

    private void ConfigureInterface()
    {
        if (_user is null)
        {
            _lblUser.Text = "Гость";
            _lblRole.Text = "Вы вошли в гостевом режиме";
            _lblCapabilities.Text = "Гостевой режим\nПросмотр доступных товаров без входа в учётную запись.";
            return;
        }

        _lblUser.Text = _user.Fio;
        _lblRole.Text = $"Роль: {RoleTitle(_user.Role)}";

        _lblCapabilities.Text = _user.Role switch
        {
            UserRole.AuthorizedClient => "Возможности клиента\nПросмотр товаров.",
            UserRole.Manager => "Возможности менеджера\nПросмотр товаров, поиск, сортировка, фильтрация и просмотр заказов.",
            UserRole.Administrator => "Возможности администратора\nВозможности менеджера, управление товарами и заказами.",
            _ => "Для этой роли возможности не настроены."
        };
    }

    private static string RoleTitle(UserRole role) => role switch
    {
        UserRole.AuthorizedClient => "Авторизованный клиент",
        UserRole.Manager => "Менеджер",
        UserRole.Administrator => "Администратор",
        _ => role.ToString()
    };

    private void btnLogout_Click(object? sender, EventArgs e) => Close();
}
