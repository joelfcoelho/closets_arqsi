const seeder   = require('mongoose-seeder');
const data     = require('./data.json');
const config   = require('../app/config/environment');
const mongoose = require('mongoose');


require('../app/models/Encomenda');

function executeSeeder(){
    mongoose.connect(config.mongoose.uri, {useNewUrlParser: true });
    mongoose.Promise = global.Promise;
    let db = mongoose.connection;

    db.on('connected', function(){
        seeder.seed(data).then(function(dbData) {
            console.log('Seeder executed successfully.');
            console.log(extractData(dbData));
            db.close();
        }).catch(function(err) {
            console.log('Error. Seeder termindated.', err);
            db.close();
        });

    });

}

function extractData(obj){
    let data = {};
    for (var key in obj.users) {
        data[key] = obj.users[key]._id;
    }
    return data;
}

executeSeeder();
