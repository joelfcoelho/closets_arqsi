const utils = require('../../components/utils');
const Encomenda = require('../../models/Encomenda');





function index() {

}


function show() {

}

function create() {

}
// POST ENCOMENDA
router.post('/', function (req, res) {

    Encomenda.create({
            id : req.body.id,
            cliente_id : req.body.cliente_id,
            itens : req.body.itens
        },
        function (err, enc) {
            if (err) return res.status(500).send("Ocorreu um erro ao adicionar informação na BD.");
            res.status(200).send(enc);
        });

});


// GET ENCOMENDA
router.get('/', function (req, res) {

    Encomenda.find({}, function (err, encomendas) {
        if (err) return res.status(500).send("Ocorreu um erro ao tentar encontrar as encomendas.");
        res.status(200).send(encomendas);
    });

});


// GET ENCOMENDA/{id}
router.get('/:id', function (req, res) {

    Encomenda.findById(req.params.id, function (err, enc) {
        if (err) return res.status(500).send("Ocorreu um erro ao tentar encontrar a encomenda.");
        if (!enc) return res.status(404).send("Encomenda não existe.");
        res.status(200).send(enc);
    });

});


// DELETE ENCOMENDA/{id}
router.delete('/:id', function (req, res) {

    Encomenda.findByIdAndRemove(req.params.id, function (err, enc) {
        if (err) return res.status(500).send("Ocorreu um erro ao tentar apagar a encomenda.");
        res.status(200).send("Encomenda "+ enc.id +" foi apagada.");
    });

});


// PUT ENCOMENDA
router.put('/:id', function (req, res) {

    Encomenda.findByIdAndUpdate(req.params.id, req.body, {new: true}, function (err, enc) {
        if (err) return res.status(500).send("Ocorreu um erro ao tentar atualizar a encomenda.");
        res.status(200).send(enc);
    });

});


module.exports = {
  index   : index,
  show    : show,
  create  : create
};
