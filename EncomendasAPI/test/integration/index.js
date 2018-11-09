const chai = require ('chai');
const app = require ('../../server');
const expect = chai.expect;
const chaiHttp = require ('chai-http');
//const item = require('../../app/api/encomendas/itens');

chai.use(chaiHttp);

describe('api/encomenda',() => {
	it('Check Status - GET /',(done) =>{

	chai.request(app) 
	.get('/api/encomenda') 
	.end((err, res,next) => { 
	expect(res).to.have.status(200); // status 200
	expect(res.body).to.be.a('Array'); // corpo da resposta é um array
	done();
});

});

describe('api/encomenda',() => {
it('Check Status - POST /',(done) =>{

	chai
	.request(app)
	.post('/api/encomenda')
	.end((err, res,next) => {
	expect(res).to.not.have.status(200); // não tem status 200 porque faz um post vazio , ou melhot tenta fazer um post sem nenhum item
	expect(res.body).to.be.a('object'); 
	//expect(res.body).to.have.property('_id');
	//expect(res.body.ok).to.be.an('string'); // variavel ok é uma string
	//expect(res.body.ok).to.be.equal("teste"); // variavel ok é igual a "teste"
	done(); 
	});
});

});

describe('api/encomenda/id',() => {
	it('Check Status - GET / ID',(done) =>{

	chai.request(app) 
	.get(`/api/encomenda/'${1}`) 
	.end((err, res,next) => { 
	expect(res).to.not.be.null;
	expect(res.body).to.be.a('Object'); 
	done();
});

});

});

describe('api/encomenda',() => {
	it('Check Status - DELETE / ID',(done) =>{
	
		chai
		.request(app)
		.del(`/api/encomenda`) 
		.end((err, res,next) => {
		expect(res).to.not.have.status(200); // não tem status 200 porque faz um delete sem id 
		expect(res).to.not.be.a('NULL'); 
		//expect(res.body.ok).to.be.an('string'); // variavel ok é uma string
		//expect(res.body.ok).to.be.equal("teste"); // variavel ok é igual a "teste"
		done(); 
		});
	});
	
	});

});