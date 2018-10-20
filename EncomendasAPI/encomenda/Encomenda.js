var mongoose = require('mongoose');
var EncomendaSchema = new mongoose.Schema({
  id: Number,
  cliente_id: String,
  itens: [Number]
});
mongoose.model('Encomenda', EncomendaSchema);

module.exports = mongoose.model('Encomenda');
