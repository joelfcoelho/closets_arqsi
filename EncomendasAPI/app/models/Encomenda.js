const mongoose  = require('mongoose');
const Schema    = mongoose.Schema;
const gda       = require('../components/gestao-armarios');


let ParteSchema = new Schema({
  idParte : {
    type    : Number,
    validate: {
      validator:  function(v){
        if (v === 0) return true;
        return gda.get('/api/parte/${v}');
      }
    }
  },

  preco   : {
    type  : Number
  },

  altura  : {
    type  : Number
  },

  largura : {
    type  : Number
  },

  profundidade  : {
    type  : Number
  },
});


let ProdutoSchema = new Schema({
  idProduto : {
    type    : Number,
    validate: {
      validator:  function(v){
        if (v === 0) return true;
        return gda.get('/api/produto/${v}');
      }
    }
  },

  preco   : {
    type  : Number
  },

  altura  : {
    type  : Number
  },

  largura : {
    type  : Number
  },

  profundidade  : {
    type  : Number
  },

  partes  : {
    type  : [ParteSchema]
  },
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

  //Teste
  // cliente_id: String,
  // itens: [Number]

});

module.exports = mongoose.model('Encomenda', EncomendaSchema);

// mongoose.model('Encomenda', EncomendaSchema);
//
// module.exports = mongoose.model('Encomenda');
