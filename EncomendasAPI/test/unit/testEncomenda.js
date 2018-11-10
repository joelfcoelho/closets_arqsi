const Encomenda = require('../../app/models/Encomenda');
const controller= require('../../app/api/encomendas/EncomendaController');
const assert  = require('chai').assert;


it('Create a new Encomenda', () => {
    let e = new Encomenda();
    let validator = e.validateSync();
    assert.notNestedProperty(validator ,'error.encomenda');
});

it('Create a new Encomenda com determninado item', () => {
    let encomenda = new Encomenda({
        itens: [{
            produtoId: '1'
        }]
    });
    let validator = encomenda.validateSync();
    assert.notNestedProperty(validator ,'error');
    
});

it('Create a new Encomenda com item errado', () => {
    let encomenda = new Encomenda({
        itens: [{
            produtoId: "rest"
        }]
    });
    let validator = encomenda.validateSync();
    assert.nestedProperty(validator ,'_message',"A encomenda não existe");
    
});
