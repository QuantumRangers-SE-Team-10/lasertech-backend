
# How to run the application locally
1. install docker (look at the bottom of this page if you don't already have docker installed)
2. download the repo
3. navigate to the directory containing the "docker-compose.yml" file, type "ls" in the terminal to confirm.
![Screenshot from 2024-02-24 20-38-11](https://github.com/QuantumRangers-SE-Team-10/lasertech-backend/assets/76791231/a83d3a11-5703-4e68-8769-df84f8f34e54)

4. Ensure your docker-compose.yml file looks like this
![Screenshot from 2024-02-24 20-36-54](https://github.com/QuantumRangers-SE-Team-10/lasertech-backend/assets/76791231/082b9d4d-79ac-4b3b-9cc8-8f0085125801)
5. run ```sudo docker compose up``` and provide the password
6. open your web browser and navigate to ```localhost:3000```

## Troubleshooting
- If your internet connection get disconnected while Docker download the image, re-run the command ```sudo docker compose up``` 
## Addtional Info
- The Backend is running at localhost:8080
- The pre-migrated PostgreSQL database is running on port 5432, you can try to connect to it with the credential in the docker compose file.


## Docker installation instruction
1. navigate to this page for reference https://docs.docker.com/engine/install/ubuntu/
2. run these commands in the terminal
3. Add Docker's official GPG key
```
sudo apt-get update
sudo apt-get install ca-certificates curl
sudo install -m 0755 -d /etc/apt/keyrings
sudo curl -fsSL https://download.docker.com/linux/ubuntu/gpg -o /etc/apt/keyrings/docker.asc
sudo chmod a+r /etc/apt/keyrings/docker.asc
```

4. Add the repository to Apt sources
``` 
echo \
  "deb [arch=$(dpkg --print-architecture) signed-by=/etc/apt/keyrings/docker.asc] https://download.docker.com/linux/ubuntu \
  $(. /etc/os-release && echo "$VERSION_CODENAME") stable" | \
  sudo tee /etc/apt/sources.list.d/docker.list > /dev/null
sudo apt-get update
```
5. Install docker packages
```
sudo apt-get install docker-ce docker-ce-cli containerd.io docker-buildx-plugin docker-compose-plugin
```
