const utils = require('../../components/utils');
const gda   = require('../../components/gestao-armarios');

function list(req, res){
    gda.get('/api/produto')
    .then(response => res.status(200).json(response.data))
    .catch(utils.handleError(req, res));
}

module.exports = {
    list       : list
};
