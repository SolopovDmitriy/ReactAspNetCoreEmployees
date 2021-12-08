import React, { Component } from 'react';
import './OnePost.css';


export class OnePost extends Component {
    static displayName = OnePost.name;

  constructor(props) {
    super(props);
    this.state = { post: null, loading: true };
  }

  componentDidMount() {
    this.populateData();
  }

    static renderForecastsTable(post) {

        /*const MainImage = require('../../../..' + post.imgSrc); */
        const MainImage = require('../../../../images/posts/1.jpg');     
        let x = '../../../..' + post.imgSrc;   

      return (

          <div>
              <h1> {x}</h1>
               {/* <!-- Page Banner -->*/}
              <div class="container-fluid no-padding page-banner">
                  {/*<!-- Container -->*/}
                  <div class="container">
                     {/* <!-- Banner Heading -->*/}
                      <div class="banner-heading">
                          <h3>{post.title}</h3>
                          <h5 class="onePost-Id hidden">{post.id}</h5>
                          <ol class="breadcrumb">
                              <li><a href="/">Главная</a></li>
                              <li><a href="/Post/index">Все Посты</a></li>
                              <li class="active">Просмотр поста</li>
                          </ol>
                      </div> {/*<!-- Banner Heading /- -->*/}
                  </div> {/*<!-- Container /- -->*/}
              </div>
                {/*<!--Page Banner / - -->*/}



                    {/*<!--Blog List-- >*/}
                <div class="container-fluid no-padding blog-list">
                    <div class="section-padding"></div>
                    {/*<!-- Container -->*/}
                    <div class="container">
                        <div class="row">
                            {/*<!-- Blog Area -->*/}
                            <div class="col-md-9 col-sm-9 col-xs-12 blog-area single-post">
                                <div class="section-title">
                                  <h3>{post.title}</h3>
                                  <p>{post.slogan}</p>
                                </div>
                              <article>
                                  <div class="entry-cover">
                                      <img src={MainImage} alt={post.imgAlt} />
                                  </div>
                                
                                  <div class="post-content">
                                      <div class="post-meta">
                                          <div class="post-date">
                                              <span> {post.dateOfPublished} </span>
                                              <span>{post.dateOfPublished}  </span>
                                          </div>
                                          <div class="post-comment">
                                              <i><img src="~/images/icon/comment.png" alt="Comment" /></i>
                                              <a href="#">17</a>
                                          </div>
                                          <div class="post-share pull-right">
                                              <a href="#"><i class="fa fa-reply"></i>Reply</a>
                                              <a href="#"><i><img src="~/images/icon/share.png" alt="Comment" /></i>Share</a>
                                          </div>
                                      </div>
                                      <h3 class="entry-title">{post.slogan}</h3>
                                      <div class="entry-content">
                                          {post.content} 
                                      </div>
                                      <div class="entry-footer">
                                          <div class="post-admin">
                                              <i><img src="~/images/icon/admin-ic.png" alt="admin-ic" /></i>Posted by<a href="#">Admin</a>
                                          </div>
                                          <div class="tags">
                                              <i><img src="~/images/icon/tags.png" alt="Tags" /></i>
                                              <a href="#">Pets</a>
                                              <a href="#">Veterinary</a>
                                              <a href="#">Dog</a>
                                              <a href="#">Ear</a>
                                              <a href="#">Cleaning</a>
                                              <a href="#">Doctor</a>
                                          </div>
                                      </div>
                                  </div>
                              </article>



                            </div>
                        </div>
                    </div>
                </div>


          </div>
                             

    );
  }

  render() {  
        let contents = this.state.loading
          ? <p><em>Loading...</em></p>
            : OnePost.renderForecastsTable(this.state.post);
        return (
          <div>
            <h1>One post </h1>        
            {contents}
          </div>
        );
  }

    async populateData() {                                   //методзапроса на сервер                                  
        const response = await fetch('post');                   //асинхронный запрос - по маршруту: employee - тип запроса GET
        const data = await response.json();                          //ответ конвертим в json   
        this.setState({ post: data, loading: false });          //меняем состояние обьекта state - инитим forecasts массив данными с сервера
    }
}
