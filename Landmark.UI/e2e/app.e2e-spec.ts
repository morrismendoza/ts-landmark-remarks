import { LandmarkRemarkPage } from './app.po';

describe('landmark-remark App', () => {
  let page: LandmarkRemarkPage;

  beforeEach(() => {
    page = new LandmarkRemarkPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
