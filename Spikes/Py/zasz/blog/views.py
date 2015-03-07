from django.http import HttpResponse
from django.shortcuts import render
from django.views.decorators.http import *
from .models import Post


@require_GET
def post_list(request):
    context = {}
    context['post_list'] = Post.objects.all()
    return render(request, 'post_list.html', context)