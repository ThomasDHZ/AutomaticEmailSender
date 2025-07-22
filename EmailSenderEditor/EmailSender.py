import sys
import traceback
import ctypes
import smtplib
import json
from email.message import EmailMessage

def sendEmail(senderEmail, senderPassword, recipientEmail, subject, message):
    msg = EmailMessage()
    msg['Subject'] = subject
    msg['From'] = senderEmail
    msg['To'] = recipientEmail
    msg.set_content(message)
    try:
        with smtplib.SMTP('smtp.gmail.com', 587) as smtp:  # Use SMTP, not SMTP_SSL
            smtp.starttls()  # Enable TLS
            smtp.login(senderEmail, senderPassword)  # Use app-specific password
            smtp.send_message(msg)
        ctypes.windll.user32.MessageBoxW(0, "Email sent successfully!", "", 0)
    except Exception as e:
        error_msg = ''.join(traceback.format_exception(*sys.exc_info()))
        print(error_msg)
        ctypes.windll.user32.MessageBoxW(0, error_msg, "Failed to send message.", 0)

def loadJsonData(config_path):
    try:
        with open(config_path, 'r') as file:
            config = json.load(file)
        senderEmail = config['senderEmail']
        senderPassword = config['senderPassword']
        recipientEmail = config['recipientEmail']
        subject = config['subject']
        message = config['message']
        sendEmail(senderEmail, senderPassword, recipientEmail, subject, message)
    except FileNotFoundError:
        print("Error: config.json not found")
    except json.JSONDecodeError:
        print("Error: Invalid JSON format in config.json")
    except KeyError as e:
        print(f"Error: Missing key {e} in config.json")

if __name__ == '__main__':
    config_path = 'config.json'
    if len(sys.argv) > 1:
        config_path = sys.argv[1]
    else:
        print("No arguments provided.")
    loadJsonData(config_path)