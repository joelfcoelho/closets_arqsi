const axios = require('axios');
const config = require('../config/environment');


function createInstance() {
  return axios.create({
    baseURL:  config.gestaoArmarios.url
  });

}

let client  = createInstance();


module.exports = client;
