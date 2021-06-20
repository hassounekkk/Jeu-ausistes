from operator import add
from sqlalchemy.ext.declarative import api
from Model import user , game , score
from flask import request , jsonify
from data import db
from data import app
from flask_restful import Api , Resource , fields , marshal, marshal_with
api = Api(app)
##################### User #######################
@app.route('/post' , methods=['POST'])
def create_db():
    data = request.get_json()
    name = data['name']
    password = data['password']
    kid = data['kid_name']
    admin = user(username=name, password= password , kid_name=kid)
    db.create_all() 
    db.session.add(admin)
    db.session.commit() 
    return 'Gooooooooood'

@app.route('/getAll')
def read_db_All():
    fetch_result = user.query.all()
    return str(fetch_result)

@app.route('/get/<username>')
def read_db(username):
    fetch_result = user.query.filter_by(username=username).first()
    return str(fetch_result) 
@app.route('/update_game/<id_game>' , )
def update_db(id_game):
    fetch_result = user.query.filter_by(id=id_game).first()
    fetch_result.username = 'hounaida'
    db.session.commit()
    return 'coool'

######################## game_dababase ####################
@app.route('/game/<name>')
def creat_gm(name):
    admin=game(game_name=name)
    db.create_all()
    db.session.add(admin)
    db.session.commit()
    return 'Created'

@app.route("/game/get/<game_name>")    
def Get_game_Id(game_name):
    admin=game.query.filter_by(game_name=game_name).first()
    return str(admin)

    
################## score #####################
@app.route('/score/<user_id>/<game_id>/')
def creat(game_id , user_id):
    admin=score(user_id=user_id , game_id=game_id  , score_of_game=0 ,Timer=0 )
    db.create_all()
    db.session.add(admin)
    db.session.commit()
    return 'cool'
@app.route("/score/<id_User>/<id_game>")
def read(id_User , id_game ):
    fetch_result = score.query.all()
    return str(fetch_result) 

@app.route('/score/update/<id_User>/<id_game>/<sc>/<time>' , )
def update_score(id_User , id_game , time , sc):
    fetch_result = score.query.filter_by(user_id=id_User).\
        filter_by(game_id=id_game).first()
    fetch_result.timer = time
    fetch_result.score_of_game = sc
    db.session.commit()
    return 'coool'

app.run(debug=True)