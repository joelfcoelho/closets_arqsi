// call the packages we need
const express = require('express');                   // call express
const app     = express();                            // define our app using express
const config  = require('./app/config/environment');
const http    = require('http').Server(app);
const gdm     = require('./app/components/gestao-armarios');


//Configure the app
require('./app/config')(app);

//let longString = gdm.get('/api/produto/2').then(produto => console.log(produto));

// REGISTER OUR ROUTES -------------------------------
// all of our routes will be prefixed with /api
app.use('/api', require('./app/api/routes.js'));

// START THE SERVER
// =============================================================================
let server = http.listen(config.port, () => {
    console.log('Express server listening on %d, in %s mode', config.port, config.env);
    //console.log('Produtos %s', longString);
});

module.exports = server; //For testing
