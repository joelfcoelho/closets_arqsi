import { AppPage } from './app.po';

describe('workspace-project App', () => {
  let page: AppPage;

  beforeEach(() => {
    page = new AppPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Encomenda de armários');
  });

  it('length of welcome message = 22', () => {
    page.navigateTo();
    var a=page.getParagraphText.toString;
    expect(a.length==22);
  });
});
