from django.conf.urls import patterns, include, url
from django.contrib import admin
import blog.views

urlpatterns = patterns('',
    url(r'^$', blog.views.post_list, name='home'),
    url(r'^post/', blog.views.post_list),
    url(r'^admin/', include(admin.site.urls)),
)
