const chai = require ('chai');
const app = require ('../server');
const expect = chai.expect;
const chaiHttp = require ('chai-http');

chai.use(chaiHttp);

describe('api/encomenda',() => {
it('Check Status - GET /',(done) =>{

	chai
.request(app) 
.get('/') 
.end((err, res) => { 
//expect(res).to.have.status(200); // status 200
expect(res.body).to.be.a('object'); // corpo da resposta é um objeto
//expect(res.body.ok).to.be.an('boolean'); // variavel ok é booleana
//expect(res.body.ok).to.be.equal(true); // variavel ok é true
done();
});

});

describe('api/encomenda',() => {
it('Check Status - POST /',(done) =>{

	chai
	.request(app)
	.post('/')
	.send({ nome: "teste" })
	.end((err, res) => {
	//expect(res).to.have.status(200); // status 200
	expect(res.body).to.be.a('object'); 
	//expect(res.body).to.have.property('_id');
	//expect(res.body.ok).to.be.an("string"); // variavel ok é uma string
	//expect(res.body.ok).to.be.equal("teste"); // variavel ok é igual a "teste"
	done(); 
	});
});

});

});