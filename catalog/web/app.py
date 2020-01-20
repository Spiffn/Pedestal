from flask import Flask
from flask_sqlalchemy import SQLAlchemy
import json

app = Flask(__name__)
app.config['SQLALCHEMY_DATABASE_URI'] = 'postgres+psycopg2://postgres@catalog-db/catalog_dev'
db = SQLAlchemy(app)


class User(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    username = db.Column(db.String, unique=True, nullable=False)
    email = db.Column(db.String, unique=True, nullable=False)


db.drop_all()
db.create_all()

db.session.add(User(username="Flask", email="example@example.com"))
db.session.commit()


@app.route('/')
def hello_world():
    users = User.query.all()

    return json.dumps(users)


if __name__ == '__main__':
    app.run(debug=True, host='0.0.0.0')
