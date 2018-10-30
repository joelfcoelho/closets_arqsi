const mongoose  = require('mongoose');
const Schema    = mongoose.schema;
//const gdm       = require('../components/gestao-armarios');


let ProdutoSchema = new schema({
  idProduto : {
    type    : Number,
    validate: {
      validator:  function(v){
        if (v === 0) return true;
        return gdm.get('/api/produto/${v}');
      }
    }
  }
});


let EncomendaSchema = new Schema({
  produtos: {
    type    : [ProdutoSchema],
    validate: {
      validator:  function(v){
          return v.length >= 1;
      },
      message : 'Uma encomenda deve ter pelo menos um produto'
    }
  }

  //info cliente
});
mongoose.model('Encomenda', EncomendaSchema);

module.exports = mongoose.model('Encomenda');
