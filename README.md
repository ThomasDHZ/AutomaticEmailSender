# AutomaticEmailSender

A lightweight C# tool for automating email sending, built with .NET Core. AutomaticEmailSender allows users to configure email subject, message, and to/from addresses via a JSON configuration file, leveraging SMTP for reliable delivery. Designed for simplicity and flexibility, it streamlines automated email workflows for applications or scripts.

## Features

- **Automated Email Sending**: Sends emails programmatically using SMTP, supporting automated notifications or alerts.
- **Configurable Settings**: Uses a JSON config file to customize subject, message body, and to/from email addresses.
- **.NET Integration**: Built for .NET Core 8.0, ensuring compatibility with modern .NET applications.
- **Lightweight Design**: Minimal codebase focused on ease of use and reliable email delivery.

## Technologies

- **Languages**: C#
- **Frameworks**: .NET Core 8.0
- **Tools**: SMTP (System.Net.Mail or MailKit), JSON configuration
- **Build System**: .NET 8.0 SDK, Visual Studio 2022

## Setup Instructions

To build and use AutomaticEmailSender:

1. **Install Prerequisites**:
   - [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).
   - Visual Studio 2022 with .NET Desktop Development workload (optional for IDE).

2. **Clone the Repository**:
   ```bash
   git clone https://github.com/ThomasDHZ/AutomaticEmailSender.git
   cd AutomaticEmailSender
   ```

3. **Build the Project**:
   - Open `AutomaticEmailSender.csproj` in Visual Studio 2022 or via CLI:
     ```bash
     dotnet build AutomaticEmailSender.csproj -c Release
     ```
   - Output: `AutomaticEmailSender.exe` in the `bin/Release/net8.0/` directory.

4. **Configure the Tool**:
   - Edit `config.json` in the project root to set email parameters (example below).
   - Ensure SMTP server credentials (e.g., Gmail, Outlook) are valid and accessible.

5. **Run the Tool**:
   - Execute the binary:
     ```bash
     dotnet run --project AutomaticEmailSender.csproj
     ```
   - The tool sends an email based on the `config.json` settings.

## Usage Example

Example `config.json` for sending an email via Gmail’s SMTP server:

```json
{
  "FromEmail": "your-email@gmail.com",
  "ToEmail": "recipient@example.com",
  "Subject": "Automated Test Email",
  "Message": "This is an automated email sent via AutomaticEmailSender.",
  "SmtpServer": "smtp.gmail.com",
  "SmtpPort": 587,
  "SmtpUsername": "your-email@gmail.com",
  "SmtpPassword": "your-app-specific-password"
}
```

Run the tool to send the configured email:

```bash
dotnet run
```

**Note**: For Gmail, use an [App Password](https://support.google.com/accounts/answer/185833) for secure authentication.

## Contributing

Contributions are welcome! Fork the repository, create a feature branch, and submit a pull request. For major changes, open an issue to discuss ideas.

## License

[MIT License](LICENSE) - free to use and modify for personal or commercial projects.
