const mongoose  = require('mongoose');
const Schema    = mongoose.Schema;
const gda       = require('../components/gestao-armarios');


let ItemSchema = new Schema({
  idProduto   : {
    type      : Number,
    required  : true,
    validate: {
      validator:  function(v){
        if (v === 0) return true;
        return gda.get('/api/produto/${v}');
      }
    }
  },

  preco   : {
    type      : Number,
    required  : [true, 'O preço é obrigatório.']
  },

  altura  : {
    type      : Number,
    required  : [true, 'A altura é obrigatória.']
  },

  largura : {
    type      : Number,
    required  : [true, 'A largura é obrigatória.']
  },

  profundidade  : {
    type      : Number,
    required  : [true, 'A profundidade é obrigatória.']
  },

  // itens  : {
  //   type  : [this],
  //   validate: {
  //     validator:  function(v){
  //       if (v === 0) return true;
  //       return gda.get('/api/produto/${v}/partes');
  //     }
  // },
});


let EncomendaSchema = new Schema({
  // cliente:  {
  //   type      : mongoose.Schema.Types.ObjectId,
  //   ref       : 'User',
  //   required  : true
  // },

  itens: {
    type    : [IemSchema],
    validate: {
      validator:  function(v){
          return v.length >= 1;
      },
      message : 'Uma encomenda deve ter pelo menos um produto.'
    }
  }




});

module.exports = mongoose.model('Encomenda', EncomendaSchema);
