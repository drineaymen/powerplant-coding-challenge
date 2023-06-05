# powerplant-coding-challenge


## Welcome !

### Prerequisites

1. Using dotnet:

Please make sure that you have dotnet installed on the machine. This projet needs dotnet 6.0 or higher to run.
In case you need to to download dotnet please refer to this following link: https://dotnet.microsoft.com/en-us/download

2. Using docker:

Please make sure that docker installed on your machine. If not, please refer to this following link in order to dowload and install docker: https://docs.docker.com/get-docker/
### To start the API on port 8888:

- Locate the app foler.
- Start a new terminal.

### Using dotnet:

#### - Execute the folowing command:
    dotnet run --project /powerplant-coding-challenge.csproj --environment Production

### Using docker:

1. Build your image:

#### docker build -t powerplant-coding-challenge

2. Run container

#### docker run --name powerplant-coding-challenge -p 8888:80 -d engieapowerplant-coding-challengepi

### Swagger && Documentation

Please refer to to this url https://localhost:8888/swagger/index.html 