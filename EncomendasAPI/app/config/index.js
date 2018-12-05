const mongoose   = require('mongoose');
const bodyParser = require('body-parser');
const config     = require('./environment');
const cors       = require('cors');



function configureMongoose(){
    mongoose.connect(config.mongoose.uri, {useNewUrlParser: true }); // connect to our database
    mongoose.Promise = global.Promise;
    let db = mongoose.connection;

    if(config.env !== 'test'){
        db.on('error', console.error.bind(console, 'Connection error:'));
        db.on('connected', console.info.bind(console, 'Successfully connected to mongoose database'));
    }
}

module.exports = (app) => {
    configureMongoose();

    // configure app to use bodyParser()
    // this will let us get the data from a POST
    app.use(bodyParser.urlencoded({ extended: true }));
    app.use(bodyParser.json());

    // Enable cors requests
    app.use(cors());
};
