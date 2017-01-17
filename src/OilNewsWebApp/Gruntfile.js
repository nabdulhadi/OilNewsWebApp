/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {
  // load Grunt plugins from NPM
  grunt.loadNpmTasks('grunt-contrib-concat');
  grunt.loadNpmTasks('grunt-contrib-uglify');
  grunt.loadNpmTasks('grunt-contrib-watch');

  // configure plugins
  grunt.initConfig({
    uglify: {
      movies: {
        files: { 'wwwroot/moviesApp.js': ['Scripts/**/movies*.js'] }
      },
      oils: {
        files: { 'wwwroot/oilsApp.js': ['Scripts/**/oils*.js'] }
      }
    },

    concat: {
      options: {
        separator: ' '
      },

      movies: {
        src: ['Scripts/moviesApp.js', 'Scripts/**/movies*.js'],
        dest: 'wwwroot/moviesApp.js'
      },

      oils: {
        src: ['Scripts/oilsApp.js', 'Scripts/**/oils*.js'],
        dest: 'wwwroot/oilsApp.js'
      }
    },

    watch: {
      scripts: {
        files: ['Scripts/**/*.js'],
        tasks: ['concat']
        //tasks: ['uglify']
      }
    }
  });

  // define tasks
  //grunt.registerTask('default', ['uglify', 'watch']);
  grunt.registerTask('default', ['watch', 'concat']);
};