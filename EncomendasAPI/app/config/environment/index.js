const _ = require('lodash');

let env = process.env.NODE_ENV || 'development';

// All configurations will extend these options
// ============================================
let all = {
    env: env,

    // Server port
    port: process.env.PORT || 3000,

    // Mongoose connection
    mongoose: {
        uri: 'mongodb://arqsi2018:arqsi2018@ds014808.mlab.com:14808/encomendasapi'
    }

    /*jwt: {
        secret   : "fSk35bzq6KutR0dQVKTL",
        issuer   : "http://projeto.arqsi.local",
        audience : "Everyone"
    },

    gestaoArmarios: {
        url      : 'http://your_azure_app.net',
        email    : 'email@example.com',
        password : 'password'
    },*/


};

// Export the config object based on the NODE_ENV
// ==============================================
module.exports = _.merge(
    all,
    require(`./${env}.js`)
);
