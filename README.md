README

Connecting to server with WSL

Step 1
Copy the SSH key to a location in your WSL shell.

cp /mnt/c/Users/<USER>/Downloads/<YOUR_KEY.pem> ~/.ssh/

Step 2
Change the key's permissions

chmod 600 ~/.ssh/<YOUR_KEY.pem>

Step 3
Connect to your VM

ssh -i ~/.ssh/<YOUR_KEY.pem> azureuser@YOUR_VM_PUBLIC_IP
