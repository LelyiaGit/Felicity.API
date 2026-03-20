README

Connecting to server with WSL

Step 1
Copy the key to a location in your WSL shell.

cp /mnt/c/Users/<USER>/Downloads/<YOUR_KEY.pem> ~/.ssh/

Step 2
Change the key's permissions

chmod 600 ~/.ssh/<YOUR_KEY.pem>

Step 3
Connect to your VM

ssh -i ~/.ssh/<YOUR_KEY.pem> azureuser@YOUR_VM_PUBLIC_IP


Docker

Building and running the Docker container using Docker compose
docker compose up -d --build


Migrations

dotnet ef migrations add <MIGRATION_NAME> --project Felicity.Repository --startup-project Felicity.API

dotnet ef database update --project Felicity.Repository --startup-project Felicity.API

dotnet ef database update --connection "Host=localhost;Port=5432;Database=felicitydb;Username=felicityuser;Password=WelcomeToFelicity;SSL Mode=Disable" --project Felicity.Repository --startup-project Felicity.API