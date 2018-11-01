const mongoose  = require('mongoose');
const Schema    = mongoose.Schema;
const gda       = require('../components/gestao-armarios');


// let ProdutoSchema = new schema({
//   idProduto : {
//     type    : Number,
//     validate: {
//       validator:  function(v){
//         if (v === 0) return true;
//         return gda.get('/api/produto/${v}');
//       }
//     }
//   }
// });


let EncomendaSchema = new Schema({
  // produtos: {
  //   type    : [ProdutoSchema],
  //   validate: {
  //     validator:  function(v){
  //         return v.length >= 1;
  //     },
  //     message : 'Uma encomenda deve ter pelo menos um produto'
  //   }
  // }

  //info cliente

  //Teste
  cliente_id: String,
  itens: [Number]

});

module.exports = mongoose.model('Encomenda', EncomendaSchema);

// mongoose.model('Encomenda', EncomendaSchema);
//
// module.exports = mongoose.model('Encomenda');
