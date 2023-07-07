pipeline {
  agent any
  environment  {
      APPNAME  =  "lab001"
      IMAGE  =  "lab001"
      PORT  =  "8091"
      VERSION  =  14
      REGISTRY  ="achoto"
      DOCKER_HUB_LOGIN  =  credentials('dockerhub-achoto')
  }
  stages  {
    stage('Build Image'){
      steps  {
        sh  "pwd"
        sh  'docker build  -t  $REGISTRY/$IMAGE:$VERSION  .'
      }
    }
    stage('Docker Push to Docker-hub'){
      steps  {
        sh  'docker login --username=$DOCKER_HUB_LOGIN_USR --password=$DOCKER_HUB_LOGIN_PSW'
        sh  'docker push $REGISTRY/$APPNAME:$VERSION'
      }
    }
    stage('Deploy Image'){
      steps  {
        sh  'docker run -d --name $APPNAME -p $PORT:80 $REGISTRY/$IMAGE:$VERSION'
      }
    }    
  }
}
