FROM debian:latest

RUN apt-get update -y
RUN apt-get install -y python-pip python-dev build-essential

COPY . /catalog-app
WORKDIR /catalog-app

RUN pip install -r web/requirements.txt

ENTRYPOINT [ "python" ]

CMD ["web/app.py"]
