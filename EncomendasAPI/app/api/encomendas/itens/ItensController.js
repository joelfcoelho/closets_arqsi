const utils     = require('../../../components/utils');
const Encomenda   = require('../../../models/Encomenda');


function findItem(encomendaId, itemId){
  return new Promise((resolve, reject) => {
      Encomenda.findOne({_id: encomendaId})
      .then(encomenda => {
          if(!encomenda){
              return reject({error: 'not_found', message: 'A encomenda não existe'});
          }

          return encomenda.itens.id(itemId);
      })
      .then(item => {
          if(!item){
              reject({error: 'not_found', message: 'O item não foi encomendado'});
          }

          return resolve(item);
      })
      .catch(() => reject({error: 'not_found', message: 'A encomenda não existe'}));
  });


}


function show(req, res){
  findItem(req.params.encomendaId, req.params.itemId)
  .then(item => res.status(200).json(item))
  .catch(err => res.status(404).json(err));
}
