import os
import sys
import json

config_data = {
    "senderEmail": "",
    "senderPassword":"",
    "recipientEmail":"",
    "subject":"Hi there from python script, loading data from json.",
    "message":"This is an auto email."}

save_path = os.path.join(os.environ['APPDATA'], 'EmailSender', 'config.json')

fileDirectory = os.path.join(os.environ['APPDATA'], 'EmailSender')
if not os.path.exists(fileDirectory):
    os.makedirs(fileDirectory)

if __name__ == '__main__':
    config_path = ''
    if len(sys.argv) > 1:
        config_path = sys.argv[1]
    else:
        print("No arguments provided.")

    if not os.path.isfile(save_path):
        with open(save_path, 'w') as json_file:
            json.dump(config_data, json_file, indent=4)
