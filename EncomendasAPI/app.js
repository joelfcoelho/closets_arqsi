var express = require('express');
var app = express();
var db = require('./db');

var EncomendaController = require('./encomenda/EncomendaController');
app.use('/Encomenda', EncomendaController);

module.exports = app;
