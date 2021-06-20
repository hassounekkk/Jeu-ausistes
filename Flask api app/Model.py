from threading import Timer
from data import db
import json
class user(db.Model):
    id=db.Column(db.Integer, primary_key=True ,  autoincrement=True)
    username = db.Column(db.String(80), unique=True)
    kid_name = db.Column(db.String(120))
    password = db.Column(db.String(120))
    last_date=db.Column(db.DateTime , nullable=True)
    score = db.relationship('score', lazy='dynamic')
    def __init__(self, username, password , kid_name):
        self.username = username
        self.password = password
        self.kid_name = kid_name
    def __repr__(self):
        return json.dumps({'id': self.id  , 'name': self.username , 'password': self.password , 'kid_name': self.kid_name})



class game(db.Model):
    game_id=db.Column(db.Integer, primary_key=True ,  autoincrement=True)
    game_name = db.Column(db.String(80), unique=True)
    score = db.relationship('score', lazy='dynamic')
    def __init__(self, game_name):
        self.game_name=game_name
    def __repr__(self):
        return  json.dumps({'game_id': self.game_id  , 'game_name': self.game_name})


class score(db.Model):
    score_id=db.Column(db.Integer, primary_key=True ,  autoincrement=True)
    user_id=db.Column(db.Integer , db.ForeignKey(user.id))
    game_id=db.Column(db.Integer , db.ForeignKey(game.game_id))
    score_of_game = db.Column(db.Integer , nullable=True )
    timer = db.Column(db.Float , nullable=False )
    Date_jeu = db.Column(db.DateTime , nullable=True )

    def __init__(self, user_id , game_id , score_of_game , Timer ):
        self.game_id=game_id
        self.user_id=user_id
        self.score_of_game=score_of_game
        self.timer=Timer
    def __repr__(self):
        return  json.dumps({'score': self.score_of_game  , 'timer': self.timer})
        
