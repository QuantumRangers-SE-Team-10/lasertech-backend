
# How to run the application locally
1. install docker (look at the bottom of this page if you don't already have docker installed)
2. donwload the repo
3. navigate to the directory containing the "docker-compose.yml" file, type "ls" in the terminal to confirm. 
4. run ```sudo docker compose up``` and provide the password



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
