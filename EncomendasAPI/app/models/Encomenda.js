const mongoose  = require('mongoose');
const Schema    = mongoose.Schema;
const gda       = require('../components/gestao-armarios');


let ParteSchema = new Schema({
  idParte     : Number,
  nome        : String,
  preco       : Number,
  altura      : Number,
  largura     : Number,
  profundidade: Number,
});


let ItemSchema = new Schema({
  idProduto   : {
    type      : Number,
    required  : true,
    validate: {
      validator:  function(v){
        if (v === 0) return true;
        return gda.get(`/api/produto/${v}`);
      }
    }
  },

  // Fields to populate from the gda api
  preco       : Number,
  altura      : Number,
  largura     : Number,
  profundidade: Number,
  itens       : [ParteSchema],
});


let EncomendaSchema = new Schema({

  itens: {
    type    : [ItemSchema],
    validate: {
      validator:  function(v){
          return v.length >= 1;
      },
      message : 'Uma encomenda deve ter pelo menos um produto.'
    }
  }

});


//  Validate and populate Produto fields from gda api
ItemSchema.pre('save', true, function(next, done){

  next(); // next middleware to be executed

  let promises = [];

  promises.push(this.isModified('idProduto') ? gda.get(`/api/produto/${this.idProduto}`) : {});   // Fetch produto data if idProduto was modified, otherwise return {}
  // promises.push(this.isModified('idProduto') ? gda.get(`/api/produto/${this.idProduto/partes}`) : {});

  let that = this;


  Promise.all(promises)
  .then(function(responses){
    let produto = responses[0].data;
    // let parte   = responses[1].data;

    // if(parte){
    //   that.idParte = parte.parteID;
    //   that.nome = parte.nome;
    //   that.preco = parte.preco;
    //   that.altura = parte.altura;
    //   that.largura = parte.largura;
    //   that.profundidade = parte.profundidade;
    // }

    if(produto){
      that.preco = produto.preco;
      that.altura = produto.altura;
      that.largura = produto.largura;
      that.profundidade = produto.profundidade;
      // that.itens = produto.itens.push({
      //   idParte : parte.ParteID,
      //   nome  : parte.nome,
      //   preco : parte.preco,
      //   altura : parte.altura,
      //   largura : parte.largura,
      //   profundidade : parte.profundidade,
      // });
    }


    done(); //This middleware is finished



  })
  .catch(err => done(err));

});



module.exports = mongoose.model('Encomenda', EncomendaSchema);
