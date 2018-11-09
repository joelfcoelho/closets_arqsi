const utils = require('../../components/utils');
const Encomenda = require('../../models/Encomenda');




function index(req, res) {

  let query = {};

  Encomenda.find(query)
  .then(encomendas => {
    return res.status(200).json(encomendas);
  })
  .catch(utils.handleError(req, res));
}



function show(req, res) {

  let query = {
    _id : req.params.id
  };

  Encomenda.findOne(query)
  .then(encomenda => {
    if (!encomenda) {
      return res.status(404).json({error: 'not_found', message: 'Esta encomenda não existe'});
    }
    res.status(200).json(encomenda);
  })
  .catch(utils.handleError(req, res));
}



function create(req, res) {

  let encomenda   = new Encomenda();
  let itens       = req.body.itens  ||  [];

  encomenda.itens = itens.map(i =>  {
    if (!i.idProduto) {
      i.idProduto = 0;
    }
    return  i;
  });

  encomenda.save()
  .then(e => {
    return res.status(200).json(e);
  })
  .catch(utils.handleError(req, res));

}


function remove(req, res) {

  let query = {
    _id : req.params.id
  };

  Encomenda.findByIdAndRemove(query)
  .then(encomenda =>  {
    if(!encomenda) {
      return res.status(404).json({error: 'not_found', message: 'Esta encomenda não existe'});
    }
      res.status(200).send("Encomenda apagada.");
  })
  .catch(utils.handleError(req, res));
}


function edit(req, res) {

  let query = {
    _id : req.params.id
  };

  Encomenda.findById(query)
  .then(encomenda => {
    if(!encomenda) {
      return res.status(404).json({error: 'not_found', message: 'Esta encomenda não existe'});
    }

    for (let attr in req.body) {
      encomenda[attr] = req.body[attr];
    }

    encomenda.save()
    .then(e => {
      res.status(200).json(e);
    })
    .catch(utils.handleError(req, res));

  })
  .catch(utils.handleError(req, res));

}


module.exports = {
  index   : index,
  show    : show,
  create  : create,
  remove  : remove,
  edit    : edit
};
